using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private bool isBoss;
    [SerializeField] private int HPBoss;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if(!isBoss)
            {
                Die();
            }
            else
            {
                HPBoss -= 1;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(HPBoss <= 0 && isBoss)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject); // hu? k? ??ch sau khi ch?t

    }
}
