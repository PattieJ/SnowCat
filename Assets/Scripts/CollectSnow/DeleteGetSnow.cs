using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGetSnow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delete());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
