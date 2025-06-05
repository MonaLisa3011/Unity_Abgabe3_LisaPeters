using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Feind : MonoBehaviour
{
    [SerializeField] GameObject VerlorenPanel;
    
    [SerializeField] GameObject StartPanel;
    
    [SerializeField] Button Nochmal2Button;
    
    [SerializeField] Button StartButton;
    
    private void Start()
    {
        VerlorenPanel.SetActive(false);
        
        Nochmal2Button.onClick.AddListener(RestartGame);
        StartButton.onClick.AddListener(StartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowVerlorenPanel()
    {
        VerlorenPanel.SetActive(true);
    }
    
    void StartGame()
    {
        StartPanel.SetActive(false);
    }
    void Update()
    {}
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag ("Feind"))
        {
            //Destroy(gameObject);
            ShowVerlorenPanel();
        }    
    }
    
    
}

