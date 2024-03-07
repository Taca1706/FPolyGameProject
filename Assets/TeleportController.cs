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
            if (collision.CompareTag("Player"))
            {
                transform.Translate(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z));
                isOpened = true;
                teleBtnMenu.SetActive(true);
                Time.timeScale = 0;
                animator.SetBool("isTouch", true);
            }
        }
    }
    public void TeleportToPoint()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) > 0.5f)
        {
            Player.transform.position = new Vector2(transform.position.x + 1.5f, transform.position.y);
        }
        teleBtnMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
