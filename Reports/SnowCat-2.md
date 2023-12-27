# SnowCat制作过程-2

+ # Game-2游戏制作

## 0.素材准备



+ 下载透明底矢量图素材

+ 利用photoshop对素材图片进行换色、切割等处理

  

## 1.制作随机出现的雪花



1. + 创建 ` Create Empty ` ，命名为 `snow1` ，将 `Position` 中的 `X、Y、Z` 值改为 `0` 。
   + 添加雪花图片 `snow1.png` 和箭头图片 `arrow_snow_.png` ，同样将 `Position` 中的 `X、Y` 值改为 `0` .为确保箭头图片显示在雪花图片上层，将 `arrow_snow_` 对应的 `Z` 值改为-1， `snow_1` 对应的 `Z` 值改为 `0` 。
2. 为雪花 `snow1` 添加动画使其旋转。
   + 试用 `Animation` ，旋转速度不平均，改用编写C#代码实现。
   + 为增加趣味性，旋转速度 `spinSpeed` 通过 `Random` 函数获得。
3. 根据同样的步骤制作不同的雪花，命名为  `snow2、snow3、snow4` 并存放到 `Prefabs` 中。



## 2.积分的显示



1. + 创建 `UI` 对象，在其中添加空对象 `Score` 。
   + 在 `score` 中添加 `Text` 对象命名为 `ScoreTable` 用来显示积分数值，添加 `Image` 对象命名为 `Snowball` 用来装饰积分条。

2. + 修改积分数值显示字体。

   <img src=".\reportsAssets_2\scoreTableFont.png" style="zoom:50%;" />

   

## 3.制作判定圆环





画面分屏

主屏按键

小屏猫猫捡雪花