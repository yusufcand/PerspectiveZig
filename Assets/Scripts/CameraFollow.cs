using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    Vector3 offset;
    [SerializeField] float lerpRate;
    public bool gameOver;
    
    void Start()
    {
        gameOver = false;
        offset = ball.transform.position - transform.position;
    }
    
    void Update()
    {
        if (gameOver == false)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
