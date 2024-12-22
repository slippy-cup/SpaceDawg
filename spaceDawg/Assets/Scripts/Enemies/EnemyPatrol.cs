using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;

    private Vector3 initScale;
    private bool movingLeft; 

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                //change direction
                DirectionChnage();
            }
            
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                //change direction
                DirectionChnage();

            }
        }
        
    }

    private void DirectionChnage()
    {
        //negates the value of moving left
        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        //Make the enemy face the direction
        enemy.localScale = new Vector3(initScale.x * _direction,
            initScale.y, initScale.z);

        //Move the enemy in the direction 
        enemy.position = new Vector3(enemy.position.x  + Time.deltaTime * _direction,
            enemy.position.y, enemy.position.z);
    }
}
