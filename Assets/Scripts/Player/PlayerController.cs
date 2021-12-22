using UnityEngine;

// This script handles controlling the player movement
public class PlayerController : MonoBehaviour
{
    // A reference to the Sprite Renderer componenet, holding the player image
    public SpriteRenderer playerImage;

    private Rigidbody2D rb;

    private Vector3 change;

    public Camera cam;

    private float ySpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        // getting rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // getting input of vertical axis
        change.y = Input.GetAxisRaw("Vertical");
        // calling move function
        Move();
    }

    void Move()
    {
        // using rigid body to move player
        rb.velocity = new Vector3 (1f, change.y * ySpeed);
    }
}
