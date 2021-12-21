using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer sr;
    private Animator anim;
    [SerializeField]
    private float movementSpeed = 10f;
    private float moveX;
    private bool isJump;
    bool isHurt, isDead;
    bool facingRight = true;


    void Awake()
    {

        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        body.velocity = new Vector2(moveX * movementSpeed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && !isJump)
        {
            Jumo();
        }

        if (moveX > 0)
        {
            sr.flipX = false;
        }

        else if (moveX < 0)
        {
            sr.flipX = true;
        }

        setAnimation();
    }

    private void setAnimation()
    {
        anim.SetBool("isWalk", moveX != 0);
        anim.SetBool("isJump", isJump);
    }

    private void Jumo()
    {
        body.gravityScale = 2;
        body.velocity = new Vector2(body.velocity.x, movementSpeed);
        isJump = true;

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit");
        if (col.gameObject.tag == "ground")
        {
            isJump = false;
            body.gravityScale = 1;
        }
        else if (col.gameObject.tag == "Fire")
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            isDead = true;
            anim.SetBool("isDead", isDead);
            this.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (col.gameObject.tag == "Virus")
        {
            // player mati dan semua pergerakkan didisabled
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            isDead = true;
            anim.SetBool("isDead", isDead);
            this.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        
    }

    public bool CanAttack()
    {
        return moveX == 0 && !isJump;

    }

    

}
