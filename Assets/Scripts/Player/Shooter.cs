using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// This script allows the player to shoot projectiles by instantiating them during run-time/gameplay
public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;

    public AudioSource audioShoot;

    public TextMeshProUGUI reload;

    public Transform bulletPosition;

    int ammoNum = 30;

    bool isReloading = false;


    // Start is called before the first frame update
    void Start()
    {
        //getting audio component
        audioShoot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if there is no ammo then reload
        if (ammoNum == 0 && !isReloading)
        {
            isReloading = true;
            StartCoroutine(Reload());
        }
        // if player presses R then continue
        if (Input.GetKeyDown(KeyCode.R))
        {
            // if player has anything but not 30 bullets then start reloading
            if (ammoNum != 30)
            {
                ammoNum = 0;
                StartCoroutine(Reload());
            }
        }

        // Check if the player pressed the spacebar, mapped to the Jump input in project settings, to make them shoot
        if (Input.GetKeyDown(KeyCode.Space))
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
            GameObject bulletOne = Instantiate(projectilePrefab, new Vector2(gameObject.transform.position.x + 0.4f, gameObject.transform.position.y + 0.7f), Quaternion.identity);
            GameObject bulletTwo = Instantiate(projectilePrefab, new Vector2(gameObject.transform.position.x + 0.4f, gameObject.transform.position.y - 0.7f), Quaternion.identity);

            bulletOne.GetComponent<Rigidbody2D>().velocity = bulletOne.transform.right * 10f;
            bulletTwo.GetComponent<Rigidbody2D>().velocity = bulletOne.transform.right * 10f;

            // substract two bullets
            ammoNum = ammoNum - 2;

            // play shooting sound
            audioShoot.Play();

            // display current bullets
            reload.text = string.Format("Ammo: " + ammoNum + "/30");
        }
    }

    IEnumerator Reload()
    {
        // display reloading text
        reload.text = string.Format("Reloading");

        //wait 2 sec
        yield return new WaitForSeconds(2);

        // add 30 ammo
        ammoNum = 30;

        // display current bullets
        reload.text = string.Format("Ammo: " + ammoNum + "/30");

        isReloading = true;
    }

}
