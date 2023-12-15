using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public float smooth = 0.5f;

    // Update is called once per frame
    void LateUpdate()
    {

        if (Player != null)
        {
            Vector3 playerPos = new Vector3(Player.position.x, Player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPos, smooth);
        }
    }
}
