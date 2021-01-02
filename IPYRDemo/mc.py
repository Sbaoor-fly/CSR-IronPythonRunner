def runcmd(cmd):
	'''执行后台命令'''
	pass
def logout(msg):
	'''向控制台以标准流输出'''
	pass
def getOnLinePlayers():
	'''获取在线玩家'''
	pass
def getPlayerAbilities(uuid):
	'''获取uuid对应玩家能力表'''
	pass
def getPlayerAttributes(uuid):
	pass
def getPlayerEffects(uuid):
	'''获取uuid对应玩家所有属性表'''
	pass
def getPlayerPermissionAndGametype(uuid):
	'''获取uuid对应玩家权限与游戏模式'''
	pass 
def getscoreboard(uuid,boardname):
	'''获取uuid对应玩家特定计分板上的数值'''
	pass
def addPlayerItem(uuid,id,aux ,count):
	'''为uuid对应玩家添加count个特殊值为aux，物品id为id的物品'''
	pass
def setCommandDescribe(key,descripition):
	'''设置一个指令为key，描述为description的指令'''
	pass
def teleport(uuid,x,y,z,did):
	'''传送uuid对应玩家到维度id为did的x，y，z处'''
	pass
def setPlayerBossBar(uuid,title,percent):
	'''设置uuid对应玩家标题为title，百分比为percent的怪物血条'''
	pass
def setPlayerSidebar(uuid,title,list):
	'''设置uuid对应玩家标题为title，内容为list的侧边栏'''
	pass
def getPlayerItems(uuid):
	'''获取uuid对应玩家物品'''
	pass
def setPlayerPermissionAndGametype(uuid, modes):
	'''设置uuid对应玩家权限和游戏模式'''
	pass
def disconnectClient(uuid,tips):
	'''强制断开uuid对应玩家的连接，提示为tips'''
	pass
def transferserver(uuid,addr,port):
	'''传送uuid对应玩家到IP为addr的服务器port端口'''
	pass
def talkAsw(uuid,msg):
	'''模拟uuid对应玩家说一句话'''
	pass
def getPlayerMaxAttributes(uuid):
	'''获取uuid对应玩家最大能力表'''
	pass
def sendSimpleForm(uuid,title,contest,buttons):
	'''向uuid对应玩家发送一个简单的表单，返回表单id'''
	pass
def releaseForm(formid):
	'''放弃一个表单id为formid的表单'''
	pass
def removePlayerBossBar(uuid):
	'''移除uuid对应玩家自定义血条'''
	pass
def removePlayerSidebar(uuid):
	'''移除uuid对应玩家自定义计分板'''
	pass
def sendCustomForm(uuid,json):
	'''向uuud对应玩家发送一个自定义表单'''
	pass
def sendModalForm(uuid, title, contest, button1,button2):
	'''向uuid对应玩家发送一个模式对话框'''
	pass
def reName(uuid,name):
	'''重命名uuid对应玩家'''
	pass 
def runcmdAs(uuid,cmd):
	'''模拟uuid对应玩家执行一个指令'''
	pass
def sendText(uuid,msg):
	'''向uuid对应玩家发送一段文字'''
	pass
def setServerMotd(motd,isshow):
	'''设置服务器motd，isshow是一个bool值'''
	pass
def creatGUI():
    '''创建GUI对象'''
    pass
def creatPlayerObject(uuid):
    '''创建玩家指针操作对象'''
    pass


'''load_name'''
#xuid —— 玩家对应xuid
#uuid ——玩家对应uuid
#playername —— 玩家名称
#ipport —— 玩家IP与端口
'''player_left'''
#xuid —— 玩家对应xuid
#uuid ——玩家对应uuid
#playername —— 玩家名称
'''server_command'''
#cmd —— 后台输入的指令
'''attack'''
#actorname —— 被攻击实体名称
#playername ——攻击者名称
#dimensionid —— 玩家所在维度ID
#XYZ —— 玩家所处位置
'''inputtext'''
#msg —— 输入的文本
#dimensionid —— 玩家所在维度ID
#XYZ —— 玩家所在位置
'''destoryblock'''
#blockid —— 方块id
#XYZ —— 玩家所在位置
#position —— 方块所在位置
#blockname —— 方块名称
'''mobdie'''
#scrname —— 伤害源名称
#mobname —— 实体名称
#dimensionid —— 生物所在维度ID
#playername —— 若为玩家死亡则附带此项
'''respawn'''
#XYZ —— 玩家所在位置
#dimensionid —— 玩家所在维度ID
#playername —— 玩家名称
'''inputcommand'''
#cmd —— 玩家输入的指令
#dimensionid —— 玩家所在维度ID
#playername —— 玩家名称
#XYZ —— 玩家所在位置
'''equippedarm'''
#itemid —— 物品id
#itemcount —— 物品数量
#itemname —— 物品名字
#itemaux —— 物品特殊值
#solt —— 操作格子
#XYZ —— 玩家所在位置
'''formselect'''
#formid —— 表单id
#selected —— 选择项
#uuid —— 玩家uuid
#playername —— 玩家名称
'''useitem'''
#itemid —— 物品id
#itemcount —— 物品数量
#itemname —— 物品名字
#itemaux —— 物品特殊值
#playername —— 玩家名称
#XYZ —— 玩家所在位置
#position —— 方块所在位置
'''placeblock'''
#XYZ —— 玩家所在位置
#position —— 方块所在位置
#blockid —— 方块id
#blockname —— 方块名字
#dimensionid —— 方块所在维度ID
'''levelexplode'''
#blockid —— 爆炸方块id
#entityid —— 爆炸实体id
#blockname —— 爆炸方块名称
#entityname—— 爆炸实体名称
#position —— 爆炸所在位置
#explodepower —— 爆炸强度
#dimensionid —— 爆炸所在维度ID
'''npccmd'''
#npcname —— npc名称
#actionid —— 选择项
#actions —— 指令列表
#position —— npc所在位置
#entityid —— ncp实体id
#entityname —— npc实体名称
#dimensionid —— npc所在维度ID
'''pistonpush'''
#targetposition —— 被推动的方块所在位置
#targetblockid —— 被推动的方块id
#targetblockname ——被推动的方块名称
#dimensionid —— 活塞所在维度ID
#blockid —— 活塞id
#blockname —— 活塞名称
'''blockcmd'''
#cmd —— 执行的命令
#position —— 命令方块所在位置
#dimensionid —— 命令方块所在维度ID
#type —— 执行者类型
#tickdelay —— 执行间隔
'''openchest'''
#XYZ —— 玩家所在位置
#position —— 箱子所在位置
#blockid —— 箱子id
#blockname —— 箱子名字
#dimensionid —— 箱子所在维度ID
'''closechest'''
#XYZ —— 玩家所在位置
#position —— 箱子所在位置
#blockid —— 箱子id
#blockname —— 箱子名字
#dimensionid —— 箱子所在维度ID
