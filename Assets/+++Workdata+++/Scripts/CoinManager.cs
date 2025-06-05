using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private int coinCounter = 0;
    [SerializeField] private UIManager uimanager;

    public void AddCoin()
    {
        coinCounter++;
        uimanager.UpdateTextCoinCount(coinCounter);
    }
}
