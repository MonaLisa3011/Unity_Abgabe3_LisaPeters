using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scheune : MonoBehaviour
{
    [SerializeField] GameObject GewonnenPanel;
    
    [SerializeField] Button NochmalButton1;
    
    private void Start()
    {
        GewonnenPanel.SetActive(false);
        
        NochmalButton1.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowGewonnenPanel()
    {
        GewonnenPanel.SetActive(true);
    }
    
    void Update()
    {}
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Scheune"))
        {
            //Destroy(gameObject);
            ShowGewonnenPanel();
        }    
    }
}
