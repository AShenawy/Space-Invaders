using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speed;
    private float timer;
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        // change camera position according to player's with offset 
        transform.position = new Vector3(player.position.x + offset.x, 0, offset.z);
    }
}
