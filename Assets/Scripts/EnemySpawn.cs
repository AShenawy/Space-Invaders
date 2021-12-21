using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    float timer = 0f;
    public GameObject enemyPrefab;
    public GameObject player;
    private SpriteRenderer spriteRenderer;
    public Sprite[] planeSprites;
    public Camera cam;
    private float rightScreenEdge;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if timer is less than 1.5f (sec) than add time.deltatime
        if (timer <= 1.5f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            // if it is bigger than spawn enemy and reset timer
            timer = 0;
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        // find what is right screen angle to spawn enemies there
        rightScreenEdge = cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth, 0)).x;
        GameObject enemyPlane = Instantiate(enemyPrefab, new Vector2(rightScreenEdge, Random.Range(-4.5f, 4.5f)), Quaternion.identity); //spawn in random Y axis from -4.5f to 4.5f

        // get object's sprite component 
        spriteRenderer = enemyPlane.GetComponent<SpriteRenderer>();

        // adding box collider to the object
        enemyPlane.AddComponent<BoxCollider2D>();

        // making sure that the object has trigger
        enemyPlane.GetComponent<BoxCollider2D>().isTrigger = true;

        //randomly selecting the sprite and putting it
        spriteRenderer.sprite = planeSprites[Random.Range(0, 3)];
    }
}
