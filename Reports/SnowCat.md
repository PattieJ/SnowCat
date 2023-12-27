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

   + 创建 `animation controller` ，（在animation文件夹中），命名为Player，拖到player里
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

### 1. 移动背景并循环播放

1. 创建脚本，将leftMove 设为(1,0,0) moveSpeed设为-2 可使背景向左移动

   ```C#
   gameObject.transform.position += Leftmove * moveSpeed * Time.deltaTime;
   ```

   

2. 循环背景：当到达边界的时候，将背景1移到背景2的后面，依次循环

   ```c#
   this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 2 * width, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
   ```

   

### 2. 动态水

学习了Unity中带有Sprite Shape的2D水教程

1. 创建一个Sprite Shape -> closed shape

2. 创建一个 Sprite Mask，并调整想要的形状

   <img src=".\reportsAsserts\maskShape.png" alt="image-20231219185050122" style="zoom:50%;" />

3. 将sprite shape里的mask interaction改为 visible inside mask

   <img src=".\reportsAsserts\visibleMask.png" alt="image-20231219185148419" style="zoom:50%;" />

4. 点击Edit spline可以修改形状和添加点

   <img src=".\reportsAsserts\editLine.png" alt="image-20231219185241993" style="zoom:50%;" />

5. 添加脚本，挂载到sprite shape上，通过脚本控制点的移动，设置为正弦移动

6. 若是不清楚每个点对应的号，可以通过

   ```C#
   for (int i = 0; i < spline.GetPointCount(); i++)
   {
       splinePos[i] = spline.GetPosition(i);
   }
   ```

   获取每个点的坐标，然后移动每个点，查看每个点都是第几个

   > 经过测试,应该移动的点应该为2\3\4\5\6\7

7. 通过公式设置角度达成效果(参数细节可能有所调整，但大致效果如下)

   <img src=".\reportsAsserts\wave.gif" alt="wave" style="zoom:50%;" />

### 3. 掉入水面时有重力水花效果

思路：给每个水面的点绑定一个球，给球设置碰撞体（设置成trigger模式），从而实现出入水面时有重力效果

水花效果思路：使用Polygon Collider2D检测碰撞，当存在碰撞的时候，使用粒子系统发射水花动画

在油管上找到了水花的 [制作教程](https://www.youtube.com/watch?v=0Kt7gLaoB18)

但感觉这种方式还是太假了，尝试用回原始的2D的像素帧的方式吧

问题1： 缝隙问题

<img src=".\reportsAsserts\gap.png" alt="image-20231219234539706" style="zoom:50%;" />

添加一个atlas，但是图片会变得很模糊，在Unity里打开Edit/Project Settings/Quality,然后把这一项设置为disabled，解决

问题2：给水体加一段碰撞体检测：添加tilemap collider 2D，选择use composite，再添加composite collision 2D

<img src=".\reportsAsserts\collision.png" alt="image-20231220015052162" style="zoom:50%;" />

<img src=".\reportsAsserts\composite.png" alt="image-20231220015152441" style="zoom:50%;" />

问题3：出入水时的水花制作

DONE，splash挂载在water上，设置的y轴为-1

### 4. 人物头像、氧气条、记分UI

+ #### 创建人物头像

  + 在canvas里创建一个image，导入框框，调整位置

  + 制作头像

    + 在image里再创建一个image，命名为cut，此时为一个和frame相同大小的白色框框

    + 在cut里再创建一个image，命名为face，拖入idle状态的图片，调整位置至只有头在框框里

      <img src=".\reportsAsserts\face.png" alt="image-20231227134426888" style="zoom:50%;" />

    + 在cut中添加一个组件 `mask`，再取消 show mask graphic

      <img src=".\reportsAsserts\mask.png" alt="image-20231227134351693" style="zoom:50%;" />

    + 移动cut到合适的位置

+ #### 创建氧气条UI

1. 创建UI 的 canvas并添加image，将frame拖入，点击**set native size**恢复尺寸

   <img src=".\reportsAsserts\setSize.png" alt="image-20231220023042251" style="zoom:50%;" />

2. 再添加一个image，将fill拖入，移动到合适位置并设置合适的图层关系之后，新建一个空的gameobjcet包含frame和fill。

   <img src=".\reportsAsserts\healthbar.png" alt="image-20231220143652515" style="zoom:50%;" />

3. 将fill的img type进行修改，如下所示，滑动amount可以看见变化（法1）

   <img src="E:\GameProject\SnowCat\Reports\reportsAsserts\fill.png" alt="image-20231227142517216" style="zoom:50%;" />

4. 给healthBar添加slider组件，然后对slider进行设置（法2） 此处用的是silider

   <img src=".\reportsAsserts\slider.png" alt="image-20231220143808765" style="zoom:50%;" />

5. 给healthBar添加C#脚本healthbar

6. 给player添加PlayerHealth脚本

   + 设定当猫处于wateredge之下时，血量逐减
   + 当跃出水面时，回血（水面Y轴设置为-0.8）

+ #### 创建记分UI

  + 创建雪花框框
  + 创建文本
  + 创建脚本，挂载到player上，通过脚本控制文本内容


### 5. 随机出现的小鱼

1. 给小鱼创建animator让小鱼动起来
2. 给小鱼挂载fishcontroller脚本
   + 小鱼和背景一样，一起移动
   + 超出相机的范围时销毁
   + 随机生成小鱼
3. 吃到小鱼有动画效果
   + 制作一个smoke的animi动画，并把looptime关掉
   
     <img src=".\reportsAsserts\looptime.png" alt="image-20231226222624434" style="zoom:50%;" />
   
   + 给小鱼添加碰撞并打开trigger
   
   + 碰撞后隐藏小鱼并激活smoke效果
   
   + 最后destroy掉父类



### 6. 尖刺设置

+ 尖刺动画

  done

+ cat hit动画

  + 先制作一个hit的anim
  + 在animator中，将any state与hit相连，表示任何情况下都能可能触发死亡
  + 遇到的困难：进入hit状态后无法退出了
    + 连接到Exit（这样子的效果是当长时间处于碰撞时，也会来回切换）

+ 尖刺碰撞检测(难点)

  查询到tilemap能制作动画效果！因此尝试使用tilemap来进行刺的动画设计

  !!要安装tiles插件

  + 点击点击window->packagemanager

    <img src=".\reportsAsserts\tileswindows.png" style="zoom:50%;" />

  + 点开project setting

  + 打勾

    <img src=".\reportsAsserts\packagemanager.png" style="zoom:50%;" />

  + install

    <img src=".\reportsAsserts\tilesExtract.png" style="zoom:50%;" />

+ anim tilemap的设置

  + 创建anim tilemap

  + 将number of animition 设置为对应帧数，此处设置为4

  + 在四个sprite里分别select四个帧数的图片

  + 将collider type设置为sprite，同时将flags设置为update physics

    <img src=".\reportsAsserts\animiUpdate.png" alt="image-20231225211804499" style="zoom:50%;" />

  + 将生成好的anmi tile 拖入 tile palette里

### 7. 猫咪游泳动画制作

宏定义：sample = 2

1. 自己用PS改了一下图片
2. 根据 **1** 的步骤，做出动画效果

调整触发anim动画的方式和碰撞体大小的设置，稍微合理了一些

bug: 猫猫不能跳出画面

### 8. 氧气条耗尽之后游戏结束 && 50只鱼出现后，游戏结束

预计做一个UI动画效果

1. 创建一个空对象作为菜单控制器
2. 修改panel的尺寸后，将scale设置为0
3. 编写脚本，设置几个curve，再使用携程，具体见代码
4. 修改curve曲线

+ button返回，进入第二个场景

### 9. 猫猫游泳时有泡泡动画(考虑使用粒子系统)

1. 给player添加粒子系统

2. 在renderer层调整layer

3. 在renderer层将material改为方块的default

4. 把PS的位置挪到脚下

5. 修改start size

   <img src=".\reportsAsserts\startsize.png" alt="image-20231226225258009" style="zoom:50%;" />

6. 在shape层里调整shape和scale

   <img src=".\reportsAsserts\shape.png" alt="image-20231226225513088" style="zoom:50%;" />

7. 调整粒子系统的移动方向

   <img src=".\reportsAsserts\velocity" alt="image-20231226225720504" style="zoom:50%;" />

8. 在color of lifetime层调节颜色，上面两个点负责透明度

   <img src=".\reportsAsserts\color.png" alt="image-20231226231101677" style="zoom:50%;" />

9. 把looping关掉，把play on awake关掉

10. 在此处mode改为sprite，将切割好的泡泡素材贴入

    <img src=".\reportsAsserts\bubble.png" alt="image-20231226231846112" style="zoom:50%;" />

11. 在playercontroller里改写脚本(当触发swim的时候play)

### 10. 变成雪花进入UI系统



### 11. 给水底加背景

<img src=".\reportsAsserts\swimCatbg.png" alt="image-20231226223424824" style="zoom:50%;" />

### 12. 开始游戏的UI设计

逻辑：闪烁空格+文字，按下空格时开始游戏

1. 空格闪烁：创建空格闪烁的anim

+ 增加空白帧：将时间轴移动到下一秒，点录制，然后隐藏该anim

  <img src="E:\GameProject\SnowCat\Reports\reportsAsserts\space.png" alt="image-20231227010424783" style="zoom:50%;" />

2. 因为字体比较糊，所以尝试使用textmeshpro插件

3. 开始时暂停状态，但仍希望播放anim动画，修改如下

   <img src=".\reportsAsserts\timescaleAnim.png" alt="image-20231227024204756" style="zoom:50%;" />

4. 后面改一改space

5. 改动对UImenu，按空格后才出现

### 13. 加一些小动物和装饰品丰富场景

+ 做一个大鲨鱼，碰到会hurt

### 14. 加入音乐

### 15. 设置UI

<img src="E:\GameProject\SnowCat\Reports\reportsAsserts\settingUI.png" alt="image-20231227231513275" style="zoom:50%;" />

### 

关于场景设计的新的想法：在角色半径内设置光源，随着天数逐渐点亮场景画面

