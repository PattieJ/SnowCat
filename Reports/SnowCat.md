# SnowCat制作过程

## 0. 图片切割

**宏定义**

+ Pixels Per Unit = 16

1. 修改 `spirit Mode` 为 `Multiple`
2. `Filter Mode` 修改为 `Point`
3. `Compression` 修改为 `None`
4. 点击 `Sprite Editor` 进行图片切割

## 1. 创建角色Player

养成良好的习惯：每次创建新的object的时候都要`reset`一下`transform`

**宏定义**

+ Pixels Per Unit = 64
+ walkSide sample = 10
+ back & front sample = 5
+ sleep sample = 2
+ idle sample = 2

1. + 创建 `2D object->Sprites->Square`，命名为`Player`

   + 添加 `Rigidbody 2D`，把`gravity scale`调成`0`，再添加轴约束的`Z`轴

   + `collision detection` 改为 `continuous`

     <img src=".\reportsAsserts\rigidbody.png" alt="image-20231215013414918" style="zoom:50%;" />

     TODO：三个蓝框内的属性，有待了解

   + 添加`Capsule collider 2D`，调整碰撞检测范围

     <img src=".\reportsAsserts\capsule.png" alt="image-20231215013800673" style="zoom:50%;" />

   + 创建`BlackCatController`脚本

2. `Sorting Layer` -> `add sorting Layer`, 新建一个 `Player` 层，再将 player对象 的层调整为 player。因为Player层再Default上，所以一定会显示Player再default上

   <img src=".\reportsAsserts\layers.png" alt="image-20231214222739114" style="zoom:50%;" />

3. 为角色添加图片，点击此处选择即可（此处应拖idle状态）

   <img src=".\reportsAsserts\addToPlayer.png" alt="image-20231214222901127" style="zoom:50%;" />

4. ##### 制作动画：`animation`

   + 创建 `animation controller` ，（在animation文件夹中），命名为Player
   + 在 `animation` 里 `create`，此处 create 一个 `BlackCat_SideWalk`
   + 将相应素材拖入`animator`，同时修改`sample`，调整速度

   **！素材中只有向右走，因此需要自行制作向左走**

   + 先点击录制

   + 选择`Player`的`sprite renderer`的`Flip`的X

     <img src=".\reportsAsserts\flip.png" alt="image-20231215001316524" style="zoom:50%;" />

   + 播放
   + 停止录制（结束。可每个animator检查一下是否正确）

5. ##### 连接动画：`animator `状态机

   + 修改引擎默认动画：右键点击`entry`，选择 `set stateMachine default state`之后，连接到 `idle` 状态

   + 创建 `Walk` 的混合树，选择 `blend type` 为 `2D Freedom`

   + 在`parameters`部分，添加变量`float`的 `X` `Y` 和`bool IsWalking`

     <img src="E:\GameProject\SnowCat\Reports\reportsAsserts\prama.png" alt="image-20231218200653185" style="zoom:50%;" />

   + 点击 `ADD MotionField`，添加四个状态，分别为 下、上、左、右。再根据状态上下左右调整XY值。

     <img src=".\reportsAsserts\walk.png" alt="image-20231215010904127" style="zoom:50%;" />

     检查正确方式：移动红点，看下方动画是否有相应变化

     <img src=".\reportsAsserts\testWalk.png" alt="image-20231215011238097" style="zoom:50%;" />

     

   + 右键`state`，点击`Make transition`，即可与另一个状态创建连线

     <img src=".\reportsAsserts\state_line.png" alt="image-20231215011625201" style="zoom:50%;" />

   + 点击线，将`has Exit Time`等一系列取消，至如下图

     <img src=".\reportsAsserts\ExitTime.png" alt="image-20231215011744279" style="zoom:50%;" />

   + `Condition`一栏中，添加`IsWalking`，根据逻辑，选择`true or false`

     <img src=".\reportsAsserts\condition.png" alt="image-20231215011916511" style="zoom:50%;" />

6. ##### 连接scripts，实现按键走动

   ```
   TODO: 代码逻辑思路待补充
   ```

   + `GetAxis`可能存在滑步问题，改用`GetAxisRaw`
   + `fixedUpdate` vs `update`

## 2. 设置相机跟随角色

PlanA: 直接将相机挂载到角色下

+ 但这样相机过于敏感，稍微移动角色，屏幕就会变，不是一个好方法

PlanB: 

+ `LateUpdate` vs `update`

+ player != null 的条件判断：以提供角色死亡时的情况

+ `float smooth` 数值(间断值）； `vector3.lerp()`差值计算

  Z轴需要特别处理，不能直接全用position进行差值计算。将角色的Z轴

## 3. 第一个场景绘画

1. 创建画板

   <img src=".\reportsAsserts\createPalatte.png" alt="image-20231215191619710" style="zoom:50%;" />

2. 新建tilemap

   （第一次创建的话，不需要右键Grid）右键`Grid`，选择 `2D object`，选择 `Tilemap`，选择 `Rectangular`

   <img src=".\reportsAsserts\createTilemap.png" alt="image-20231215192220317" style="zoom:50%;" />

   

3. 将图片添加到调色板中：按住切割好的图片，拖动到 `Tile Palette `中

   <img src=".\reportsAsserts\addtiles.png" alt="image-20231215180917241" style="zoom:50%;" />

4. 在`Ground` 上 画 `Plants`，新建layer Plants，并调整顺序即可

   <img src=".\reportsAsserts\tilemapPlants.png" alt="image-20231215195221983" style="zoom:50%;" />

## 4. 创建开始界面

1. 创建场景 `StartScene`，在`File`的`build setting`里，添加`StartScene`，并将其置于最顶

   <img src=".\reportsAsserts\addStartScene.png" alt="image-20231215211810384" style="zoom:50%;" />

2. 在新场景下，右键 点击`UI`，选择`panel`。将背景图片拖入`Panel`的`Image`属性中的`source Image`中

3. 右键 点击`UI`，选择`Text`，设置为title，修改内容和字体大小颜色等

4. 右键 点击`UI`，选择`Image` ,并将主角拖入`Image`属性中的`source Image`中，调整位置

5. 右键 点击`UI`，选择`button`，将`UI`图片拖入`Image`属性中的`source Image`中。分布如下

   <img src=".\reportsAsserts\startSceneLayer.png" alt="image-20231215223456465" style="zoom:50%;" />

6. 实现点击按钮时跳转到下一个场景

   + 创建脚本`StartGame`

   + ```c#
     using UnityEngine.SceneManagement;
     ```
   + 添加`component`将脚本`StartGame`拖到`button`里，然后在`button`的`onclikc()`里点添加，再将`StartGame`拖到`List`里，选择相应函数

## 5. ESC跳出菜单

**宏定义**

+ panel width:  280

+ panel height: 320

1. 创建`panel`，并修改长宽高，拖入相应`Menu`图片

   遇到一个问题：Canvas比游戏界面大特别多

   <img src=".\reportsAsserts\canvasProblem.png" alt="image-20231216010352467" />

   + 查了一些资料，canvas的大小会自适应游戏画面，因此如果不在乎美观的话，其实也无所谓（之后再找找办法调回去）

   + 还是存在一些问题，canvas并不会随着画面放大等比例放大（solution：选择canvas随画面等比例放大即可）

     <img src=".\reportsAsserts\canvasScaler.png" alt="image-20231216134501782" style="zoom:50%;" />

2. 添加C#脚本，并将脚本**挂载到相机**上

   + 实现按ESC弹出收回，需要先将canvas隐藏起来。`serializefield` -> 将`private`的值也能显示在`inspector`上。

     <img src=".\reportsAsserts\hideCanvas.png" alt="image-20231216012041447" style="zoom:50%;" />

   + 实现弹出菜单时，时间暂停

3. 创建按钮：设计到将小按钮拉长成长条按钮的问题(先不解决了，用长的替代吧)

   **宏定义**

   + Front Size:  25
   + color: 804C00

   BUG: slide滑动时内部颜色也会跟着滑动，同时滑动条右边是黑色

   <img src=".\reportsAsserts\Menu.png" alt="image-20231216202105379" style="zoom:50%;" />

## 6. 触碰物品跳转关卡

物品先暂时用火堆替代（后面再根据需求做改动）

1. 创建物品并添加碰撞属性，修改碰撞范围如下所示，要比物体大一些，避免物体重叠的时候才发生触发

   <img src=".\reportsAsserts\object.png" alt="image-20231216211511772" style="zoom:50%;" />

2. 添加刚体属性，并将`body Type`改为`Static`

3. 创建 `GameTrigger`脚本，挂载到`Obejct`上

4. 实现当和物体发生碰撞时，弹出F小标提示按下按钮

5. 当按下F时，跳出对话框表示是否进入下一个场景

6. 按下yes按钮，进入下一个场景

   + TODO：跳转的方式没想好，先做成enter跳转吧

## 7. 同步场景加载

同时也有异步场景加载，但由于本游戏不算特别复杂，暂时不考虑使用异步的方法

//决定还是先做好小游戏再做load场景吧

## 8. swimCat

### 1. 移动背景

### 2. 动态水

### 3. 空格上移 && 浮力效果

### 4. 氧气条

### 5. 随机出现的小鱼（或者固定出现）

### 6. 水草缠绕设置

### 7. 记分UI

### 8. 猫咪游泳动画制作

宏定义：sample = 2

1. 自己用PS改了一下图片
2. 根据 **1** 的步骤，做出动画效果

有点奇怪，不知道怎么改，之后再说吧

