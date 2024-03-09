using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HPSystemController : MonoBehaviour
{
    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth;
    [SerializeField] private Image[] health;
    [SerializeField] private bool isHP;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            if (isHP)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        for (int i = 0; i < maxHealth; i++)
        {
            if(i < currentHealth)
            {
                health[i].GetComponent<Animator>().SetBool("isDestroy", false);
            }
            else
            {
                health[i].GetComponent<Animator>().SetBool("isDestroy", true);
            }
        }
    }

    public void AddHealth(int heathNum)
    {
        currentHealth += heathNum;
    }
    public void RemoveHealth(int heathNum)
    {
        currentHealth -= heathNum;
    }
}
