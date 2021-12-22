using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *(Yoshio)This script was created to play BGM sounds.
 */
public class BackGroundMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] backGroundMusics;

    public void BGMSelecter() 
    {
        int randomNum = Random.Range(0, backGroundMusics.Length);
        audioSource.clip = this.backGroundMusics[randomNum];
        audioSource.Play();
    }
}
