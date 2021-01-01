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