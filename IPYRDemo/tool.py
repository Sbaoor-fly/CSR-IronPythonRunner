
def WriteAllText(path,text):
	'''覆盖式写入文件'''
	pass
def AppendAllText(path,text):
	'''向文件中追加'''
	pass 
def ReadAllLine(path):
	'''返回一个list，每个value对应文件的每一行'''
	pass
def ShareData(key,value):
	'''设置一个贡献数据'''
	pass
def GetShareData(key):
	'''获取一个共享数据'''
	pass
def ChangeShareData(key,value):
	'''修改共享数据'''
	pass
def RemoveShareData(key):
	'''移除共享数据'''
	pass
def ToMD5(text):
	'''返回test对应的md5值'''
	pass
def WorkingPath():
	'''返回bds的完整工作路径'''
	pass
def HttpPost(url,data):
	'''发起一个非异步httpPost请求'''
	pass
def HttpGet(url,data):
	'''发起一个非异步httpGet请求'''
	pass
def CreateDir(path):
	'''创建文件夹'''
	pass
def IfFile(path):
	'''判断文件是否存在'''
	pass
def IfDir(path):
	'''判断文件夹是否存在'''
	pass