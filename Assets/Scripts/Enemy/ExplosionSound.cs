using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    private AudioSource audioExplosion;

    // Start is called before the first frame update
    void Start()
    {
        audioExplosion = GetComponent<AudioSource>();
    }

    // create public function to play it in other script
    public void PlayExplosion()
    {
        audioExplosion.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
