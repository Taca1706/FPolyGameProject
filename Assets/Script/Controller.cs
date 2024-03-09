using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private HPSystemController hp;
    [SerializeField] private HPSystemController mana;

    [SerializeField] private Text goldText;

    //Thông s?
    public float Spd = 6f;
    public float DashForce = 30f;
    
    public float jumpForce = 10f;

    public float currentHP;
    public float maxHP;

    //tr?ng l?c
    public Vector2 newgravity;
    private bool isgravitychange = false;

    //anim & move
    private bool isFacingRight = true;
    float moveH;
    float moveV;
    bool isjump = true;
    bool isclimb90 = false;

    //v? trí chu?t
    //private Vector3 targetPosition;


    //??n
    public GameObject bulletPrefab;
    public float bulletSpeed = 2f;



    //firepoint
    public GameObject firePoint;


    float movePrefix = 6;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //??i tr?ng l?c
        //if(collision.gameObject.CompareTag("Wall180"))
        //{
        //    if(rb !=null)
        //    {
        //        rb.gravityScale = -2;
        //        rb.AddForce(newgravity.normalized * rb.mass * Physics2D.gravity.magnitude, ForceMode2D.Force);
        //        isgravitychange = true;
        //    }
        //}
        //if (collision.gameObject.CompareTag("nonWall"))
        //{

        //    if (rb != null)
        //    {
        //        rb.gravityScale = 1;
        //        rb.AddForce(newgravity.normalized * rb.mass * Physics2D.gravity.magnitude, ForceMode2D.Force);
        //        isgravitychange = false;
        //    }
        //}

        if(collision.gameObject.CompareTag("Ground"))
        {
            if(rb != null)
            {
                isjump = true;
                isclimb90 = false;
            }
        } 
        
        //if(collision.gameObject.CompareTag("Vground"))
        //{
        //    if(rb != null)
        //    {
        //        isclimb90 = true;
        //    }
        //}w
       



    }





    void Update()
    {
        moveH = Input.GetAxis("Horizontal");

        if(!isclimb90)
        {
            rb.velocity = new Vector2(moveH * Spd, rb.velocity.y);
            flip();
            animator.SetFloat("Speed", Mathf.Abs(moveH));
        }
        
        if(isclimb90)
        {
            rb.velocity = new Vector2(moveV * Spd, rb.velocity.x);
            animator.SetBool("Isclimb90",true);
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            isclimb90 = false;
            animator.SetBool("Isclimb90", false);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            RecoverHPByMana();
        }
        


        /*if (Input.GetKeyDown(KeyCode.A))
        {
            //spriteRenderer.flipX = true;
            rb.AddForce(Vector2.left * movePrefix * 0.5f, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //spriteRenderer.flipX = false;
            rb.AddForce(Vector2.right * movePrefix * 0.5f, ForceMode2D.Impulse);


        if (isgrachange == true)
        {
            animator.SetTrigger("Climb180");
        }
        }*/

        if (Input.GetKeyDown(KeyCode.Space) && isjump)
        {
            animator.SetTrigger("Jump");
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isjump = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("RangedAttack");
            Shoot();

        } 

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("MeleeAttack");

        }


        if (Input.GetKeyDown(KeyCode.E))
        {   
            /*targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = transform.position.x;
            //targetPosition.y = transform.position.y; // Gi? nguyên v? trí z c?a nhân v?t

            // Tính toán h??ng t? nhân v?t t?i v? trí chu?t
            Vector3 direction = targetPosition - transform.position;

            // Di chuy?n nhân v?t theo h??ng chu?t v?i t?c ?? c? ??nh trong 1 giây
            transform.position += direction.normalized * DashForce * Time.deltaTime;*/
            


            //rb.AddForce(new Vector2(DashForce, 0f), ForceMode2D.Impulse);
            //animator.SetTrigger("Dash");
        }

       

    }


    private void flip()
    {
        if (isFacingRight && moveH < 0 || !isFacingRight && moveH > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 sizeOfPlayer = transform.localScale;
            sizeOfPlayer.x *= -1;
            transform.localScale = sizeOfPlayer;
        }
    }


    void Shoot()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        mousePosition.z = 0f;


        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 direction = (mousePosition - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;
    }

    public void RecoverHPByMana()
    {
        hp.AddHealth(2);
        mana.RemoveHealth(1);
    }
}
