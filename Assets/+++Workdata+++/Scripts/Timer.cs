using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    [SerializeField] GameObject verlorenPanel;

    private bool startTimer;

    // Update is called once per frame
    public void StartTimer()
    {
        Debug.Log("hilfe");
        startTimer = true;
    }

    private void Update()
    {
        if (!startTimer) 
            return;

        Debug.Log("runnng timer");
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            verlorenPanel.SetActive(true);
        }

        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}

