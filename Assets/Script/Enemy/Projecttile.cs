using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public int baseDamageAmount = 10;
    public int damageAmount; // l??ng sát th??ng c?a viên ??n

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        damageAmount = baseDamageAmount;
    }

    // Update is called once per frame

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Controller enermy = collision.gameObject.GetComponent<Controller>(); // l?y script ?i?u khi?n k? ??ch
        if (enermy != null)
        {
            //enermy.ChangeHealth(-damageAmount); // g?i ph??ng th?c tr? máu c?a k? ??ch
        }
        Debug.Log("Projectile collision with " + collision.gameObject);

        Destroy(gameObject); //hu? viên ??n sau khi va ch?m
    }
    void Update()
    {
        if (transform.position.magnitude > 300.0f)
        {
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damage)
    {
        damageAmount = damage;
    }
}
