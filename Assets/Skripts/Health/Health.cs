using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rigidbody2;
    [SerializeField] private PlayerMovement movement;
    public float currentHealth { get; private set; }
    public bool dead { get; private set; }

    private void Awake()
    {
       // player.GetComponent<PlayerMovement>().enabled = true;
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
        movement = GetComponent<PlayerMovement>();
        rigidbody2 = GetComponent<Rigidbody2D>();
        dead = false;
    }

    public void TakeDamage(float _damage)
    {
        if (currentHealth <= 0)
            return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            //take damage
            anim.SetTrigger("hurt");
        }
        else
        {
            //Dead
            anim.SetTrigger("dead");
            movement.enabled = false;
            rigidbody2.velocity = Vector3.zero;
            dead = true;
        }
    }
}
