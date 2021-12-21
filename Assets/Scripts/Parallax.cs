using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght, starpos;
    public GameObject came;
    public float parallaxEffect;

    void Start()
    {
        // get x position
        starpos = transform.position.x;
        // find lenght of sprite
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // how far we moved relatively to the camera 
        float temp = (came.transform.position.x * (1 - parallaxEffect));

        // how far we moved from start point
        float distance = (came.transform.position.x * parallaxEffect);

        // move
        transform.position = new Vector3(starpos + distance, transform.position.y, transform.position.z);

        // if we are far from starting position + lenght then we add lenght to starting position
        if (temp > starpos + lenght) starpos += lenght;

        // if we are not far from starting position + lenght then we add lenght from starting position
        else if (temp < starpos - lenght) starpos -= lenght;


    }
}