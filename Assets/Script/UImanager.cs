using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject _iventoryPanel;
    public GameObject _storePanel;
    public GameObject _skillPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            IventoryPanel();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            StorePanel();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SkillPanel();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnGame();
        }
    }
    public void IventoryPanel()
    {
        _iventoryPanel.SetActive(true);
        _storePanel.SetActive(false);
        _skillPanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void StorePanel()
    {
        _iventoryPanel.SetActive(false);
        _storePanel.SetActive(true);
        _skillPanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void SkillPanel()
    {
        _iventoryPanel.SetActive(false);
        _storePanel.SetActive(false);
        _skillPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ReturnGame()
    {
        _iventoryPanel.SetActive(false);
        _storePanel.SetActive(false);
        _skillPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
