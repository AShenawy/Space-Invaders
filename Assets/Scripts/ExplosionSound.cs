using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // create public function to play it in other script
    public void PlayExplosion()
    {
        audio.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
