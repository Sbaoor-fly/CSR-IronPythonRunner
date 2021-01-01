#! /usr/bin/env python
# -*- coding:utf-8 -*-
import mc
import pfapi
import tool
def load_plugin():
  print('示例插件装载成功')
  
def destroyblock(a):
    d = eval(a)
    i = mc.creatPlayerObject(d['uuid'])
    print(i.ArmorContainer) #玩家装备栏
    print(i.Attack) #玩家攻击力
    print(i.Attributes) #实体属性表
    print(i.CollisionBox) #碰撞箱
    print(i.DimensionId) #实体维度
    print(i.Effects) #实体所有状态效果表
    print(i.HandContainer) #主副手栏
    print(i.Health) #生命值
    print(i.HotbarContainer) #玩家热键栏
    print(i.InventoryContainer) #背包列表
    print(i.MaxAttributes) #实体属性最大值表
    print(i.Position) #实体坐标
    print(i.Rotation) #实体转角属性
    print(i.TypeId) #实体类型ID
    print(i.UniqueId) #查询ID
    print(i.Uuid) #UUID
    print(i.getName()) #实体名字
    i.setName('Sbaoor',True) #重命名，True为是否一直显示
    i.addLevel(100) #给予玩家等级
    i.remove #从地图清除实体
    
  def placeblock(a):
    d = eval(a)
    i = mc.creatPlayerObject(d['uuid'])
    i.addLevel(100)
    gui = mc.creatGUI("test")
    gui.AddLabel("123")
    gui.AddInput('随便来的什么？','写在这里哦')
    gui.AddSlider('这是游标滑块哦',1,10)
    gui.AddToggle('这是一个开关')
    gui.AddStepSlider('这是一个矩阵滑块',0,'[1,2,3]')
    gui.AddDropdown('如你所见，下拉框',0,'[1,2,3]')
    gui.SendToPlayer(d['uuid'])
