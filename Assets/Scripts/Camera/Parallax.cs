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
        // how far we moved relative to the camera
        float temp = (came.transform.position.x * (1 - parallaxEffect));

        // distance by which we need to move the layer
        float distance = (came.transform.position.x * parallaxEffect);

        // move
        transform.position = new Vector3(starpos + distance, transform.position.y, transform.position.z);

        //starting position of the layer shall be adjusted each time the camera’s position relative to that layer’s parallax shift is greater or less than current startpos width
        if (temp > starpos + lenght) starpos += lenght;

        else if (temp < starpos - lenght) starpos -= lenght;
    }
}