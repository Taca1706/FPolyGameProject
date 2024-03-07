using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D _rb;
    [Header("Dash")]
    [SerializeField] private float Radius;
    private bool isChosingDir;
    private bool isDashing;
    [SerializeField] private float DashPower;
    [SerializeField] private float DashTime;
    [SerializeField] private GameObject Arrow;
    Vector3 DashDir;
    private float DashTimeToReset;
    [SerializeField] private float DashSkillDelayTime;
    private float DashSkillDelayCurrent;

    // Start is called before the first frame update
    void Start()
    {
        DashTimeToReset = DashTime;
        DashSkillDelayCurrent = 0;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DashSkillDelayCurrent <= 0)
        {
            Dash();
        }
        else
        {
            DashSkillDelayCurrent -= Time.deltaTime;
        }
    }
    //Dash
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Time.timeScale = 0;
            Arrow.SetActive(true);
            Arrow.transform.position = transform.position;
            isChosingDir = true;
        }
        else if (isChosingDir && Input.GetKeyUp(KeyCode.Mouse1))
        {
            Time.timeScale = 1;
            isChosingDir = false;
            isDashing = true;
            _rb.velocity = Vector2.zero;
            DashDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            DashDir.z = 0f;
            DashDir = DashDir.normalized;
            Arrow.SetActive(false);
        }

        if (isDashing)
        {
            if (DashTime > 0f)
            {
                DashTime -= Time.deltaTime;
                _rb.velocity = DashDir * DashPower * Time.deltaTime;
            }
            else
            {
                isDashing = false;
                DashTime = DashTimeToReset;
                _rb.velocity = new Vector2(_rb.velocity.x, 0);
                DashSkillDelayCurrent = DashSkillDelayTime;
            }
        }
    }
}
