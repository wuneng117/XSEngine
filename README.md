<p align="center">
这是一个基于Unity的单机卡牌游戏的框架
</p>

# 更新
2021/2/10 Base是几个主流TCG提取出来的通用部分框架，但是比较少，不同tcg之间的设计差别还是比较大的，还是需要多点时间思考下如何设计，保证尽量多的通用组件。
<br>

# 前言
- version 0.1
- 默认Unity版本 2020.1.0f1

这是一个单机卡片游戏框架，当前还处于初级阶段，仅仅完成了卡牌游戏的基础部分（可以做做扑克游戏什么的……），具体可以看《Core介绍》章节。Base是继承Core的tcg卡牌框架，还在比较基础阶段。  
<br>
目录结构如下

    XSEngine                        
    ├─ Base     (继承Core的tcg卡牌框架，未完)                    
    ├─ Common   (常用组件)                                 
    ├─ Core     (基础框架核心部分)                       
    ├─ CoreSimple   (基础框架的范例)                 
    │  └─ PokerGame (简单的出牌游戏)               
    ├─ Define   (常用定义)                                  
    └─ Extension    (扩展)                                
<br>
<br>

# Core
主要实现了：
- 所有类尽量设计得便于继承和扩展
- 借鉴 [boardgame.io](https://github.com/boardgameio/boardgame.io)，各个类可以注册各种事件回调函数，从而避免继承
- 通过状态机（fsm）实现各个阶段的管理（CoreBattleFSMBase相关类）
- 实现1个卡牌集合类（CoreCardList）封装卡组的操作
- 通过事件分发器（Emitter）抛出UI事件，游戏自己实现具体的UI刷新
## Card
一些卡牌类，实现卡牌和卡组，封装一些卡组的操作

## Manager
游戏的管理类，游戏的初始化，以及对phase类的阶段切换操作

## Phase
这个文件夹下实现了游戏状态机，通过状态机处理不同阶段（回合）的切换操作

## Player
玩家类和玩家管理类，管理玩家的属性、手牌、卡组等等
# Common
## Emitter
这个类通过system.Action，实现一个类似nodejs的EventEmitter，实现事件分发，主要是解耦一些操作，比如UI事件。

## Role
这个文件夹下主要是一些player的属性。


        