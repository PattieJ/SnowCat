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
        spline = controller.spline;//�����һȦ����

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
        currentAngle += speed * Time.deltaTime;//�Ƕ�ֵ
        if (currentAngle > 360)
            currentAngle -= 360;
        float dH1 = Mathf.Sin(currentAngle * Mathf.Deg2Rad) *strength;//2�ŵ� sin*���
        float dH2 = Mathf.Sin(currentAngle * Mathf.Deg2Rad + radDis * Mathf.Deg2Rad) * strength;//���һ����λ
        for (int i = 2; i < 7; i=i+2)
        {
            spline.SetPosition(i, splinePos[i] + new Vector2(0, dH1));
            spline.SetPosition(i+1, splinePos[i+1] + new Vector2(0, dH2));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �����봥�����Ķ����Ƿ������Ǹ���Ȥ������
        if (collision.gameObject.CompareTag("Player")) // ���衰Player������������ǩ
        {
            // ����ˮ��Ч��
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
        // ʵ����ˮ������Ч��
        if (splashParticles != null)
        {
            ParticleSystem instantiatedSplash = Instantiate(splashParticles, position, Quaternion.identity);
            ParticleSystem.MainModule mainModule = instantiatedSplash.main;
            Destroy(instantiatedSplash.gameObject, mainModule.duration + mainModule.startLifetime.constant);
        }
    }
}
