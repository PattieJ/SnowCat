using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class DestroySplash : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float time = 0.3f;
    void Start() {
        Destroy(gameObject,time);
    }

}
