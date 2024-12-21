
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //To change the speed of the player 
    [SerializeField] private float speed;


    [SerializeField] private float jumpForce;

    //Can change gravity scale in unity 
    private Rigidbody2D body;

    private Animator anim;

    private BoxCollider2D boxCollider;

    [SerializeField]  private LayerMask groundLayer; 


    private void Awake()
    {
        //Retrieves the Rigid Body from unity engine 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Retrieves input from keyboard
        float horizontalInput = Input.GetAxis("Horizontal");

        //Holds direction of the player 
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //This will flip the sprite used for walking
        if (horizontalInput > 0f)
        {
            transform.localScale = Vector3.one;
        }

        else if (horizontalInput < 0f)
        {
            transform.localScale = -(Vector3.one);
        }

        //Allows the player to Jump
        //Currently only allows players to jump if theyre on the ground
        //HAVE TO DO: SET UP DOUBLE JUMP
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();
        }

        //Set animator parameters

       
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        isGrounded();
    }

    private bool isGrounded()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(boxCollider.bounds.center,
            boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return rayCastHit.collider != null ;
    }


}
