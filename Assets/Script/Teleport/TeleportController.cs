using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportController : MonoBehaviour
{
    private GameObject Player;
    private bool isOpened;
    [SerializeField] private Button teleButton;
    [SerializeField] private GameObject teleBtnMenu;
    private bool isFirstTouch = true;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isOpened = false;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (!isOpened)
        {
            teleButton.interactable = false;
        }
        else
        {
            teleButton.interactable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if(isFirstTouch)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
                    isFirstTouch = false;
                }
                isOpened = true;
                teleBtnMenu.SetActive(true);
                animator.SetBool("isTouch", true);
                Time.timeScale = 0f;
            }
        }
    }
    public void TeleportToPoint()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) > 1f)
        {
            Player.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y + 1f);
            teleBtnMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
