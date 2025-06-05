using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoinCount;
    
    
    public void UpdateTextCoinCount(int newCount)
    {
        textCoinCount.text = newCount.ToString();
    }
    
}
