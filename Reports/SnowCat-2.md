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

2. + 修改积分数值显示字体， `Text` → `Character` → `Font` 修改字体为Import进的 `ThaleahFat_TTF`，`Font Size` 根据画面大小调整到合适数值。

   <img src=".\reportsAssets_2\scoreTableFont.png" style="zoom:50%;" />

   + 原载入的字体略宽，修改 `Scale` 中的值稍微调整以达美观。
   + 字体颜色 `Color` 修改为白色。

3. 在 `Snowball` 中挂载对应图片。

   <img src=".\reportsAssets_2\SnowballSourceImage.png" style="zoom:50%;" />

4.  `Canvas Scaler` → `UI Scale Mode` 设置积分条相对屏幕大小进行缩放与定位，并调整位置 `Position` ，使其位于右上角。

<img src=".\reportsAssets_2\ScaleWithScreen.png" style="zoom:50%;" />



## 3.制作圆环（为得分判定做准备）



1. 创建 `2D Object` → `Sprites` → `Square` ，命名为 `judgeCircle` 。
2. 创建空白 `Material` 命名为 `snowCircle` ，挂载到 `judgeCircle` 上，调整颜色。
3. 创建 `Shader` → `Standard Surface Shader` ，基于 [ 圆环实现实例 ](https://blog.csdn.net/Cake_C/article/details/122753644) 编辑代码内容实现圆环效果，挂载到 `snowCircle` 上。

<img src=".\reportsAssets_2\snowCircle.png" style="zoom:50%;" />

4. 将 `judgeCircle` 存放到 `Prefabs` 中。



## 4.实现雪花的随机出现



1. 创建一个空对象 `Player` 用于挂载代码。

2. 基于课堂练习-12/13中的内容编写C#脚本 `RandomSnow` 实现每两秒在屏幕范围内出现一片雪花。

   + 出现的雪花图片根据 `Random` 函数随机生成的数值在 `snow1~4` 之间确定。

   + 箭头的方向由随机生成的整数* `90f`  作为旋转角度实现。

   <img src=".\reportsAssets_2\RandomSnowCreate.png" style="zoom:50%;" />



## 5.判断按键消除雪花



1. 通过所生成雪花对象的旋转角度 `rotationZ` 来判断箭头所指方向。

   <img src=".\reportsAssets_2\GetRotation.png" style="zoom:50%;" />

2. 根据按键输入与 `rotationZ` 判断是否获取到雪花 `GetSnow` ，消除雪花对象，载入得到雪花的动画。

<img src=".\reportsAssets_2\JudgeKeyInput.png" style="zoom:40%;" />

3. 将该脚本挂载到 `Prefabs` 中的 `snow1~4` 上，并加入对应的雪花消失动画 `GetSnow` ，定义不同雪花的对应分数值 `Snow Score` 。

<img src=".\reportsAssets_2\JudgeSnow.png" style="zoom:50%;" />



## 6.雪花消失的动画



1. 根据宏定义切割图片后，选中要用到的 `slice` 切片自动生成 `Animation` ，命名为 `GetSnow` 。
2. 编写脚本 `DeleteGetSnow` ，实现动画播放一遍（即1s）后删除动画对象。
3. 同样的方式做出雪花Miss时的消失动画 `SnowMiss` 。



## 7.实现圆环得分判定



1. 圆环大小随时间缩放。

   + 初始值设置为原本的 `Circle` 4倍大小。
   + 定义 `scaleSpeed` 随时间变化 `localScale` 。

   <img src=".\reportsAssets_2\CircleScale.png" style="zoom:50%;" />

2. 根据 `Circle` 对象的 `localScale` 值来判断得分的等级 `gradeLevel` ，具体分为 `Prefect`、 `Great`、 `Common`、 `Miss`。

   + 当圆环缩小到足够小时，判断为 `Miss` 。

   <img src=".\reportsAssets_2\JudgeMiss.png" style="zoom:50%;" />

   + 在 `SnowGet` 中根据圆环的缩放大小值来判断得分等级。

#####                注：圆环未缩小到足够小时，转入 `MissSnow` 。

<img src=".\reportsAssets_2\JudgeGradeLevel.png" style="zoom:50%;" />

<img src=".\reportsAssets_2\JudgeMissSnow.png" style="zoom:50%;" />



## 8.显示每一个雪花的判定



+ 在 `UI` 中添加 `Text` 对象 `ScoreLevel` ，仿照 `ScoreTable` 的实现逻辑编写代码实现不同判定的显示。

<img src=".\reportsAssets_2\GetScoreLevel.png" style="zoom:50%;" />

+ 注：由于 `ScoreLevel` 采用的是 `TextMeshPro` ，在脚本中的使用需要进行一定的变化。

<img src=".\reportsAssets_2\TextMeshPro.png" style="zoom:50%;" />

+ 字体选取了系统自带的 `Bangers SDF` 。

<img src=".\reportsAssets_2\FontChoose.png" style="zoom:50%;" />



## 9.完善雪花的出现逻辑



+ 由于同一时间内最多出现3片雪花，设置两个变量记录前两个雪花的 `arrowRotation` ，通过 `while` 循环反复使用 `Random` ，来避免出现相同箭头朝向的雪花。

<img src=".\reportsAssets_2\RandomSnow.png" style="zoom:50%;" />



## 10.制作生命条



1. 制作 `UI` 中 `Image` 对象 `life1` 、 `life2` 、 `life3` ，`Source Image`设置为裁剪好的 `heart` 图片。

<img src=".\reportsAssets_2\heartSet.png" style="zoom:50%;" />

+ 这里为了避免屏幕缩放构成的 `UI` 位置错乱，将分数对象与生命值对象都调整为相对右上角。

<img src=".\reportsAssets_2\transformScore.png" style="zoom:50%;" />

2. 编辑脚本代码，实现每次 `Miss` 时生命-1，生命为零时 `GameOver`。

<img src=".\reportsAssets_2\lifeHurt.png" style="zoom:50%;" />



## 11.通过Tilemap制作背景



1. 创建 `Tilemap` 对象，选择 `Rectangular`。

<img src=".\reportsAssets_2\tilemap.png" style="zoom:50%;" />

2. 具体步骤略。

3. 为了让雪花出现在背景上层，将该 `Tilemap` 对象的 `Z` 值修改为 `2` 。在制作 `Tilemap` 中也注意雪地与树丛的 `layer` 值以达到层次效果。

   <img src=".\reportsAssets_2\tilemapLayer.png" style="zoom:50%;" />



## 12.开始前的画面



## 13.结束画面



## 14.完善UI



## 15. 增添猫爪动画（可选）



## 16.增加音乐/音效



## 17.粒子系统雪花飘落





+ # 游戏封面背景





+ # 第一日游戏场景的补全完善



1. + 对图片进行处理。 `Sprite Mode` 选择 `Multiple` ， `Pixels Per Unit` 调整为 `16` 或 `64` 或 `128` ，`Filter Mode` 选中 `Point(no filter)` ， `Compression` 调整为 `None` 。

<img src=".\reportsAssets_2\CutPhoto.png" style="zoom:50%;" />

2. + 裁剪后导入 `Tilemap` 中，保存并使用。
3. +  `Tilemap` 分层绘制等方法参照另一位的报告。