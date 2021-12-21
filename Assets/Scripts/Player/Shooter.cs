using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// This script allows the player to shoot projectiles by instantiating them during run-time/gameplay
public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;

    public AudioSource audio;

    public TextMeshProUGUI reload;

    public Transform bulletPosition;

    int ammoNum = 30;


    // Start is called before the first frame update
    void Start()
    {
        //getting audio component
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // if player presses R then continue
        if (Input.GetKeyDown(KeyCode.R))
        {
            // if player has anything but not 30 bullets then start reloading
            if(ammoNum != 30) StartCoroutine(Reload());
        }

        // Check if the player pressed the spacebar, mapped to the Jump input in project settings, to make them shoot
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // if there are bullets
        if (ammoNum != 0)
        {
            // Create an instance of the GameObject referenced by the projectilePrefab variable
            // When the instance is created, position at the same location where the player currently is (by copying their transform.position),
            // and don't rotate the instance at all - let it keep its "identity" rotation

            // create two bullets
            Instantiate(projectilePrefab, new Vector2(gameObject.transform.position.x + 0.4f, gameObject.transform.position.y + 0.7f), Quaternion.identity);
            Instantiate(projectilePrefab, new Vector2(gameObject.transform.position.x + 0.4f, gameObject.transform.position.y - 0.7f), Quaternion.identity);
   

            // substract two bullets
            ammoNum -= 2;

            // play shooting sound
            audio.Play();

            // display current bullets
            reload.text = string.Format("Ammo: " + ammoNum + "/30");
        }
        else
        {
            // if there no bullets then reload
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        // display reloading text
        reload.text = string.Format("Reloading");

        // wait 5 sec
        yield return new WaitForSeconds(5);

        // add 30 ammo
        ammoNum = 30;

        // display current bullets
        reload.text = string.Format("Ammo: " + ammoNum + "/30");
    }

}
