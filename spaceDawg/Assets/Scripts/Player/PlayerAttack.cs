
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private float attackCoolDown;

    //Determines location of where projectiles will be shot
    [SerializeField] private Transform projectileLocation;

    //Keeps track of the projectiles shot 
    [SerializeField] private GameObject[] projectileList;

    private Animator anim;

    private PlayerMovement playerMovement;

    private float coolDownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        playerMovement = GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the player presses E fireballs will shoot 
        if(Input.GetKeyUp(KeyCode.E) && coolDownTimer > attackCoolDown) 
        {
            Attack();

            coolDownTimer += Time.deltaTime;
        }
    }

    private void Attack()
    {
        coolDownTimer = 0;

        //Instead of instantiating and destroying
        //I will use object pooling for shooting 

        //Resetting the postion of each rpojectile to be aligned with the 
        //"fire point" aka projectile location
        projectileList[FindProjectile()].transform.position = projectileLocation.position;

        //Using the sign of the player's local scale on the x axis to determine which direction
        //the projectile should be shooting in 
        float direction = Mathf.Sin(transform.localScale.x);

        projectileList[FindProjectile()].GetComponent<Projectile>().SetDirection(direction);
    }

    private int FindProjectile()
    {
        for(int i =0; i< projectileList.Length; i++)
        {
            if (!projectileList[i].activeInHierarchy)
            {
                return i; 
            }
        }
        return 0;
    }
}
