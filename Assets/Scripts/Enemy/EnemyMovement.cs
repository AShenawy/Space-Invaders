using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.Find("Enemy Spawn").GetComponent<EnemySpawn>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Transform>().transform.right * speed;
    }
}
