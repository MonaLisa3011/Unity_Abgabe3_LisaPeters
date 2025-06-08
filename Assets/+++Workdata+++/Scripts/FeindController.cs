using UnityEngine;

public class FeindController : MonoBehaviour
{
    private float moveDistance = 3f;

    private float speed = 2f;
    
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.PingPong(Time.time * speed, moveDistance * 2) - moveDistance;
        transform.position = startPosition + Vector3.right * offset;
    }
}
