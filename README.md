<p align="center">
这是一个基于Unity的单机卡牌游戏的框架
</p>

# 更新
Base是几个主流TCG提取出来的通用部分框架，但是比较少，需要多点时间思考下如何设计尽量多的通用组件部分。
<br>

# 前言
- version 0.1
- 默认Unity版本 2020.1.0f1

当前这个框架还处于初级阶段，仅仅完成了卡牌游戏的基础部分，具体可以看《Core介绍》章节。后续将在这个基础上开发TCG(集换式卡牌游戏)框架。  
<br>
目录结构如下

    XSEngine/
    ├── Common/ (常用组件)
    ├── Core/   (基础框架核心部分)  
    ├── CoreSimple/ (基础框架的范例)
        └── PokerGame/ (简单的出牌游戏)
    ├── Define/ (常用定义)
    └── Extension/ (扩展)
<br>
<br>

# Core介绍
再说吧。

## Emitter
通过system.Action，实现一个简单的nodejs的EventEmitter。

# Q&A
- 插件GDE窗口打不开,提示路径detiend  
这是因为插件记录了上一次打开表格的绝对路径导致的,在需要打开的表格文件上右键用GDE重新打开就好了.

        