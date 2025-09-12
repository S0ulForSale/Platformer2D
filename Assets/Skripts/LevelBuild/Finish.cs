using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Rigidbody2D rigidbody2;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private Animator anim;
    public bool win {  get; private set; }

    private void Awake()
    {
        win = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            win = true;
            movement.enabled = false;
            rigidbody2.velocity = Vector3.zero;
            anim.SetTrigger("win");
        }
    }
}
