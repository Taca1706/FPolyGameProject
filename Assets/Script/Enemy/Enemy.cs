using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab; // prefab c?a vi�n ??n
    public float shootInterval = 2f; // th?i gian gi?a m?i l?n b?n
    public int bulletCount; // s? l??ng ??n b?n ra
    public float shootingRange = 10f; // ph?m vi b?n

    private Transform playerTransform; // transform c?a ng??i ch?i

    // Start is called before the first frame updates
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);

            // Ki?m tra xem ng??i ch?i c� trong ph?m vi b?n kh�ng
            if (IsPlayerInRange())
            {
                bulletCount = Random.Range(1, 100);
                // g�c gi?a 2 vi�n ??n li�n ti?p
                float angleStep = 360 / bulletCount;
                for (int i = 0; i < bulletCount; i++)
                {
                    //t?o vi�n ??n t? prefab
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                    // x�c ??nh h??ng b?n ng?u nhi�n c?a vi�n ??n
                    float randomAngle = UnityEngine.Random.Range(0f, 360f);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.up;

                    //thi?t l?p h??ng di chuy?n v� b?n c?a vi�n ??n
                    Projecttile projectile = bullet.GetComponent<Projecttile>();

                    if (projectile != null)
                    {
                        projectile.Launch(shootDirection, 500);
                    }
                }
            }
        }
    }

    // Ki?m tra xem ng??i ch?i c� trong ph?m vi b?n kh�ng
    private bool IsPlayerInRange()
    {
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        return distance <= shootingRange;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
