using System.Collections;
using UnityEngine;
using TMPro;
public class CountdownManager : MonoBehaviour
{
     public int countdownIndex = 3;
     public bool gameStarted = false;
     public TextMeshProUGUI countdownText;


     void Start()
     {
          StartCoroutine(Countdown());
     }

     private IEnumerator Countdown()
     {
          countdownText.gameObject.SetActive(true);

          while (countdownIndex > 0)
          {
               countdownText.text = countdownIndex.ToString();

               yield return new WaitForSeconds(1f);

               countdownIndex--;
          }

          countdownText.text = "GO";
          gameStarted = true;
          yield return new WaitForSeconds(1f);
          countdownText.gameObject.SetActive(false);

          countdownIndex = 3;
     }


}
