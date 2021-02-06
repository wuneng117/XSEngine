using System;
using XSEngine.Core;

namespace XSEngine.CoreSimple.Poker
{
    /// <summary>
    /// 这里使用一个自己定义的类来管理（这个类和Core里的类完全没有继承组合关系），表示你完全可以通过赋值Action和Func开头的委托对象，来修改Core里的类的行为而不需要继承。
    /// 如果要大量修改行为，还是通过标准方式，继承Core里的类来扩展实现。可以具体参考Base文件夹，XSEngine/Base里的机制就是通过继承Core里的类来实现的。
    /// tips：Base还没有写完，暂时没有上传。
    /// </summary>
    public class LogicMgr
    {
        /// <summary> 战斗管理类 </summary>
        public CoreBattleMgr Mgr { get; set; }
        /// <summary> 出牌区，玩家共用1个 </summary>
        public CoreCardList PlayAreaCards { get; set; }
        /// <summary> 公共牌堆，玩家共用1个 </summary>
        public CoreCardDeck PublicDeck { get; set; }

        /// <summary> 设置游戏规则 </summary>
        public void InitGame()
        {
            // 初始化战斗管理类
            this.Mgr = CoreManagerFactory.CreateBattleMgr<CoreBattleMgr>(
                // 公共牌堆的牌抽完了算游戏结束
                FuncCheckGameEnd: (mgr) => {
                    // TODO 在这里是麻将的胡牌算法，就不写了
                    return false;
                },
                // 玩家打一张牌之后结束他的回合
                ActionOnUseCard: (mgr, card) => mgr.TurnEnd()
            );

            // 初始化玩家管理类
            var playerMgr = CorePlayerFactory.CreatePlayerMgr<CorePlayerMgr>();
            this.Mgr.SetPlayerMgr(playerMgr);

            // 生成公共牌堆，所有玩家共用一个，麻将一共136张
            this.PublicDeck = CoreCardFactory.CreateCardDeck<CoreCardDeck>();
            for (var i = 0; i < LogicDefine.START_PUBLIC_CARDS; i++)
            {
                // 每种4张，共34种
                var index = (int)(i/4);
                var card = CoreCardFactory.CreateCard<CoreCard>(index, "No." + index);
                this.PublicDeck.Add(card);
            }

            // 生成出牌区，所有玩家共用一个
            this.PlayAreaCards = CoreCardFactory.CreateCardList<CoreCardList>();

            // 生成玩家，生成最大数量
            for (var i = 0; i < Core.Const.Config.PLAYER_NUM_MAX; i++)
            {
                // 这个比较特殊，玩家共用一个出牌堆
                var newPlayer = CorePlayerFactory.CreatePlayer<CorePlayer>(
                    index: i,
                    turnTrigger: this.Mgr,
                    publicDeck: this.PublicDeck,

                    // 玩家回合开始响应事件
                    ActionOnTurnBegin: (player) =>
                    {
                        // 抽一张牌，然后看看是否游戏结束
                        player.HandCards.Add(player.PublicDeck.RemoveTop());
                        player.TryGameEnd();
                        // 发送事件刷新UI
                        CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_HANDCARDS_CHANGED, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(player.Index));
                        CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_PUBLICDECK_CHANGED, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(player.Index));

                        if (player.Index != 0)
                            player.UseCard(player.HandCards.CardArray[0]);
                    },

                    // 玩家游戏开始响应事件
                    ActionOnGameStart: (player) =>
                    {
                        // 洗牌，抽起始手牌
                        player.PublicDeck.Shuffle();
                        player.HandCards.Add(player.PublicDeck.RemoveTop(LogicDefine.START_HAND_CARDS));

                        // 发送事件刷新UI
                        CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_HANDCARDS_CHANGED, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(player.Index));
                        CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_PUBLICDECK_CHANGED, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(player.Index));
                    },

                    // 玩家能否使用这张卡的响应事件
                    FuncCanUseCard: (player, card) => this.Mgr.IsCurPlayer(player) && player.HandCards.Count > 0 && player.HandCards.Contains(card),

                    // 玩家使用这张卡的响应事件
                    ActionOnUseCard: (player, card) =>
                    {
                        // 再判断下是否出牌成功
                        if (!player.HandCards.Remove(card))
                            return;
                        // 使用的牌打到出牌区
                        player.PlayAreaCards.Add(card);
                        // 发送事件刷新UI
                        CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_HANDCARDS_CHANGED, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(player.Index));
                        CoreUIEmitter.Instance.Emit(CoreUIEmitter.UI_PLAYAREACARDS_CHANGED, CoreFactory.CreateUIEmitterData<CoreUIEmitterData>(player.Index));
                    }
                );

                newPlayer.PlayAreaCards = this.PlayAreaCards;
                playerMgr.AddPlayer(newPlayer);
            }
        }
        /// <summary> 别忘了每帧更新 </summary>
        public void Update() => this.Mgr.Update(this.Mgr);
    }
}