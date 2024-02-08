# 客户端框架

## ClientShared(公用部分)

> 不需要参与热更新的纯C#稳定代码

1. Addressable/Assetbundle
2. ObjectPool
	- bilibili.com/video/BV1Su411E7b2
	- CountAll|CountActive|CountInactive|实时显示系统状态
	- 内存泄漏，性能下降，卡顿;
	- 减少频繁创建销毁的成本，实现循环复用;
	- 2021.3，官方UnityEngine.Pool;
3. InputSystem
4. NetworkSystem

## xLua/HybridCLR

1. UI
2. GameLogic

# 服务器框架

> https://blog.csdn.net/qq_33531923/article/details/126944150

1. GateServer 网关服
2. LoginServer 登录服
3. LobbyServer 大厅服
4. GameServer 游戏服（多开）
5. WebServer WebAPI（邮件/签到/奖励），Blazor后台管理系统
