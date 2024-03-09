using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField] private HPSystemController hPSystemController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hPSystemController != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                hPSystemController.RemoveHealth(1);
            }
        }
    }
}
