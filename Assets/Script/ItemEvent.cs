using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEvent : MonoBehaviour
{
   
    
    private int _coin;
   
    // Start is called before the first frame update
    void Start()
    {
        _coin = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>()._coinValue;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Destroy(this.gameObject);
            _coin += 1000;
           
            
        }
    }
}
