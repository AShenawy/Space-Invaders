using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script controls the behaviour of each single Alien enemy
public class EnemyBehaviour : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip destroySFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DestroyEnemy", 5f);
    }

    void DestroyEnemy()
    {
        // Destroy the game object this script is on (the projectile game object)
        Destroy(gameObject);

    }

    // A function automatically triggerred when another game object with Collider2D component
    // Enters the Collider2D boundaries on this game object
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            // if player collided set playerprefs for gameover scene
            PlayerPrefs.SetString("loseMessage", "YOUR SHIP WAS DESTROYED");

            // load gameover scene
            SceneManager.LoadScene("GameOver");
        }

            // Check the tag on the other game object. If it's the projectile's tag,
            //  destroy both this game object and the projectile
        if (otherCollider.tag == "Projectile")
        {
            // play explosion sound
            GameObject.Find("ExplosionSound").GetComponent<ExplosionSound>().PlayExplosion();

            // destroy object
            Destroy(gameObject);
			
			// Get the game object, as a whole, that's attached to the Collider2D component
            Destroy(otherCollider.gameObject);
        }
    }
}
