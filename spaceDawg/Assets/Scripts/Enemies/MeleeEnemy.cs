using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    //Enemy Attack
    [SerializeField] private float attackCoolDown;
    [SerializeField] private int damage;

    //Enemy line of sight 
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;

    //Enemy's line of sight 
    [SerializeField] private BoxCollider2D boxCollider;

    //Layer which Enemy is on
    [SerializeField] private LayerMask playerLayer;

    private float coolDownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private Health playerHealth;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponent<EnemyPatrol>();
    }


    private void Update()
    {
        coolDownTimer += Time.deltaTime;


        if (PlayerInSight())
        {
            //Attack hen player is only in sight.
            if (coolDownTimer >= attackCoolDown)
            {
                Debug.Log("Hit");
                //Attack
                coolDownTimer = 0;
                DamagePlayer();
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0,
            Vector2.left,
            0,
            playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
             new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        //Player will take damage if its in sight. 
        if (PlayerInSight())
        {
            //Damage Player health
            playerHealth.TakeDamage(damage);
        }
    }
}
