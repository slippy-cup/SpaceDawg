using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    private float direction; 

    private bool hit;

    private BoxCollider2D boxCollider;

    private Animator anim;

    private float lifetime;
    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;

        //Determines the speed of the projectile being shot 
        float movementSpeed = speed * Time.deltaTime * direction;

        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;

        //prevents the projectile floating in space endlessly if it does
        // not collide with anything. 
        if(lifetime> 5 )
        {
            gameObject.SetActive(false);
        }
    }

    //Checks for collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When the projectile collides with an object, it marks it as hit 
        hit = true; 
        boxCollider.enabled = false;

        collision = boxCollider;

        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

        if(collision.CompareTag ("Enemy"))
        {
            collision.GetComponent<Health>().TakeDamage(1);
        }

    }

    //Sets the direction of the projectile
    public void SetDirection(float _direction)
    {

        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true); 
        hit = false; 
        boxCollider.enabled = true;

        //flips the projectile based on direction 
        float localScaleX = transform.localScale.x;

        //flips the projectiles depending if the player shoots 
        //left or right
       if(Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX =  -localScaleX;
        }
    

        transform.localScale = new Vector3(
            localScaleX,
            transform.localScale.y,
            transform.localScale.z) ;
       
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
