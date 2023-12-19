using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class WaterController : MonoBehaviour
{
    public int index = 0; public float height = 0;
    private SpriteShapeController controller;
    private Spline spline;
    public List<Vector2> splinePos = new List<Vector2>();
    public float speed;
    public float radDis;
    public float currentAngle = 0;
    public float strength;
    public ParticleSystem splashParticles;
    // Use this for initialization
    void Awake()
    {
        controller = GetComponent<SpriteShapeController>();
        spline = controller.spline;//外面的一圈的线

        for (int i = 0; i < spline.GetPointCount(); i++)
        {
            splinePos.Add(spline.GetPosition(i));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < spline.GetPointCount(); i++)
        {
            splinePos[i] = spline.GetPosition(i);
        }*/
        currentAngle += speed * Time.deltaTime;//角度值
        if (currentAngle > 360)
            currentAngle -= 360;
        float dH1 = Mathf.Sin(currentAngle * Mathf.Deg2Rad) *strength;//2号点 sin*振幅
        float dH2 = Mathf.Sin(currentAngle * Mathf.Deg2Rad + radDis * Mathf.Deg2Rad) * strength;//多加一个相位
        for (int i = 2; i < 7; i=i+2)
        {
            spline.SetPosition(i, splinePos[i] + new Vector2(0, dH1));
            spline.SetPosition(i+1, splinePos[i+1] + new Vector2(0, dH2));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 检查进入触发器的对象是否是我们感兴趣的物体
        if (collision.gameObject.CompareTag("Player")) // 假设“Player”是你的物体标签
        {
            // 播放水花效果
            //Debug.Log("1");
            CreateSplashEffect(collision.transform.position);
        }
        else
        {
            return;
        }
    }

    void CreateSplashEffect(Vector3 position)
    {
        // 实例化水花粒子效果
        if (splashParticles != null)
        {
            ParticleSystem instantiatedSplash = Instantiate(splashParticles, position, Quaternion.identity);
            ParticleSystem.MainModule mainModule = instantiatedSplash.main;
            Destroy(instantiatedSplash.gameObject, mainModule.duration + mainModule.startLifetime.constant);
        }
    }
}
