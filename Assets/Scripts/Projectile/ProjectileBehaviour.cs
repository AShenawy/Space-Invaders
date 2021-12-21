using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the behaviour of the projectile game object
public class ProjectileBehaviour : MonoBehaviour
{
	// How fast will the project travel
    private float speed = 15f;
	
	// How much time, in seconds, before the projectile destroys itself (if it hits nothing and escapes the play area)
    public float destroyAfter = 2f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Call the DestroyProjectile function (note its written as string, this is how Invoke takes its parameter)
        // after a specific amount of time (seconds) set by the destroyAfter variable
        Invoke("DestroyProjectile", destroyAfter);
    }

    // Update is called once per frame
    void Update()
    {
        // As soon as the projectile is instantiated in the game scene, transform.Translate will start
        // moving it up one unit, multiplied by the speed and Time.deltaTime for cpu optimisation

        // Get a global space vector and multiply by 1
        Vector2 bulletVelocity = rb.GetRelativeVector(Vector2.right * 1f);
        // add rigidbody velocity
        bulletVelocity += rb.velocity;
        //rigidbody velocity is now vector2 that moves bullet
        rb.velocity = bulletVelocity;
    }

    void DestroyProjectile()
    {
		// Destroy the game object this script is on (the projectile game object)
        Destroy(gameObject);
        
    }
}
