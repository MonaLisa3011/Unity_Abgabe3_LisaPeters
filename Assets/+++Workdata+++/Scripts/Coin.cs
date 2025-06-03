using UnityEngine;

public class Coin : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {}
    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Coin")
            {
                Destroy(other.gameObject);
            }
        }
}
