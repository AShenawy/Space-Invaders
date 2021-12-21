using UnityEngine;

// This script handles controlling the player movement
public class PlayerController : MonoBehaviour
{
    // A reference to the Sprite Renderer componenet, holding the player image
    public SpriteRenderer playerImage;

    private Rigidbody2D rb;

    private float moveSpeed = 1f;

    private Vector3 change;

    public Camera cam;
    private float timer = 1f;

    private float ySpeed = 4f;

    private float topEdge;
    private float bottomEdge;


    // Start is called before the first frame update
    void Start()
    {
        // getting rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if time is less or quels to 1 sec than add time.deltatime
        if (timer <= 1f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            // if it is bigger than add move speed of 0.05f to the player
            timer = 0;
            moveSpeed = moveSpeed + 0.05f;
        }
        
        // x is current move speed
        change.x = moveSpeed;
        // getting input of vertical axis
        change.y = Input.GetAxisRaw("Vertical");
        // calling move function
        Move();
    }

    public float PlayerSpeed()
    {
        return moveSpeed;
    }

    void Move()
    {
        // using rigid body to move player
        rb.MovePosition(transform.position  + change * ySpeed * Time.fixedDeltaTime);
    }
}
