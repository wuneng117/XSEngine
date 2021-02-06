using XSEngine.Core;
using UnityEngine;
using UnityEngine.UI;
using XSEngine.CoreSimple.Poker;
using System.Collections.Generic;

public class GameScene : MonoBehaviour
{
    public GameObject playerPrefab; // 玩家预制体
    public GameObject cardPrefab;   // 卡牌预制体
    public GameObject canvas;   // ui根节点
    public CoreConfig config;   // 配置文件
    public GameObject panelPlayerArea;  // 出牌区节点
    public Text textPublickDeckNum; // 公共牌堆数量显示
    [SerializeField]
    private List<GameObject> playerPanelArray;
    public List<GameObject> PlayerPanelArray { get => playerPanelArray; set => playerPanelArray = value; }
    public LogicMgr LogicMgr { get; private set; }  // 游戏管理

    void Awake()
    {
        // 初始化游戏
        InitGame();
        // 注册UI事件
        CoreUIEmitter.Instance.On(CoreUIEmitter.UI_PLAYAREACARDS_CHANGED, (data) => this.RefreshPlayerArea(), 0, this);
        // 刷新公共牌堆数量
        CoreUIEmitter.Instance.On(CoreUIEmitter.UI_PUBLICDECK_CHANGED, (data) => this.textPublickDeckNum.text = this.LogicMgr.PublicDeck.Count.ToString(), 0, this);
    }

    void OnDestroy()
    {
        // 注销UI事件
        CoreUIEmitter.Instance.Off(CoreUIEmitter.UI_PLAYAREACARDS_CHANGED, this);
        CoreUIEmitter.Instance.Off(CoreUIEmitter.UI_PUBLICDECK_CHANGED, this);
    }

    /// <summary> 初始化游戏 </summary>
    private void InitGame()
    {
        // 游戏设置
        Const.SetConfig(this.config);
        // 生成游戏管理
        this.LogicMgr = new LogicMgr();
        this.LogicMgr.InitGame();
        // 生成玩家UI节点
        for (var i = 0; i < this.PlayerPanelArray.Count; i++)
        {
            var playerPanel = this.PlayerPanelArray[i];
            var player = this.LogicMgr.Mgr.PlayerMgr.PlayerArray[i];
            if (player != null)
            {
                var cpt = playerPanel.GetComponent<PlayerPanel>();
                cpt.Init(player as CorePlayer);
            }
            else
                playerPanel.SetActive(false);
        }
    }


    /// <summary> 刷新出牌区 </summary>
    private bool RefreshPlayerArea()
    {
        ClearPlayerArea();

        this.LogicMgr.PlayAreaCards.ForEach(card =>
        {
            var cardNode = GameObject.Instantiate(this.cardPrefab);
            cardNode.transform.SetParent(this.panelPlayerArea.transform);
            var cpt = cardNode.GetComponent<CardNode>();
            cpt.Init(card as CoreCard, null);
        });
        return true;
    }

    /// <summary> 清理出牌区 </summary>
    private void ClearPlayerArea()
    {
        for (var i = this.panelPlayerArea.transform.childCount - 1; i >= 0; i--)
            Destroy(this.panelPlayerArea.transform.GetChild(i).gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        this.LogicMgr.Mgr.GameStart();
    }
}
