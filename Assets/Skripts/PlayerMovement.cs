using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    private Animator anim;

    private AudioManager audioManager;
    private bool wasGrounded;
    private void Start()
    {
        audioManager = AudioManager.Instance;
    }
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip player when moving left-right
        if (horizontalInput > 0.1f)
            transform.localScale = new Vector3(5, 5, 1);
        else if (horizontalInput < -0.1f)
            transform.localScale = new Vector3( -5, 5, 1);

        if (Input.GetKey(KeyCode.Space))
            Jump();

        bool isCurrentlyGrounded = isGrounded();

        if (isCurrentlyGrounded && !wasGrounded)
        {
            // Відтворюємо звук приземлення, якщо гравець щойно приземлився
            audioManager.PlaySFX(SFXType.Land); // Або інший звук приземлення, якщо у вас є
        }

        // Оновлюємо прапорець для наступного кадру
        wasGrounded = isCurrentlyGrounded;



        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

    }
    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
            audioManager.PlaySFX(SFXType.Jump);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f,groundLayer);
        return raycastHit.collider != null;
    }

    public void PlayWalkSound()
    {
        audioManager.PlaySFX(SFXType.Walk);
    }
}
