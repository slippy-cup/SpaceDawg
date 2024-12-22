using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float startingHealth;

    public float currentHealth { get; private set; }

    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float invulnerabilityDuration;
    [SerializeField] private float numFlashes;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        Debug.Log(currentHealth);
        currentHealth = Mathf.Min(currentHealth - _damage, startingHealth);

        Debug.Log(currentHealth);
        if(currentHealth > 0)
        {
            //player hurt
            StartCoroutine(Invulerability());
        }
        else
        {
            if(!dead)
            {
                Debug.Log("Dead");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;    
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Min(currentHealth + _value, startingHealth);
        Debug.Log(currentHealth);
    }

    private IEnumerator Invulerability()
    {
        Physics2D.IgnoreLayerCollision(11, 12, true);

        for(int i = 0; i < numFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(invulnerabilityDuration/ (numFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invulnerabilityDuration / (numFlashes * 2));
        }


        Physics2D.IgnoreLayerCollision(11, 12, false);
    }
   
}
