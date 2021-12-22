using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the behaviour of the projectile game object
public class ProjectileBehaviour : MonoBehaviour
{

	// How much time, in seconds, before the projectile destroys itself (if it hits nothing and escapes the play area)
    public float destroyAfter = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Call the DestroyProjectile function (note its written as string, this is how Invoke takes its parameter)
        // after a specific amount of time (seconds) set by the destroyAfter variable
        Invoke("DestroyProjectile", destroyAfter);
    }

    void DestroyProjectile()
    {
		// Destroy the game object this script is on (the projectile game object)
        Destroy(gameObject);
    }
}
