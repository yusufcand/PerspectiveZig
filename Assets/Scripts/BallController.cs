using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody rb;
    bool started;
    bool gameOver;
    public GameObject particle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        started = false;
        gameOver = false;
    }

    
    void Update()
    {
        if (started == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.linearVelocity = new Vector3(speed, 0, 0);
                started = true;
                
                GameManager.GMinstance.StartGame();
            }
        }

        if (Physics.Raycast(transform.position, Vector3.down, 1f) == false)
        {
            gameOver = true;
            rb.linearVelocity = new Vector3(0, -25f, 0);
            
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            
            GameManager.GMinstance.GameOver();
        }
        
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        
        if (Input.GetMouseButtonDown(0) && gameOver == false)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if (rb.linearVelocity.z > 0)
        {
            rb.linearVelocity = new Vector3(speed, 0, 0);
        }
        else if (rb.linearVelocity.x > 0)
        {
            rb.linearVelocity = new Vector3(0, 0, speed);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            GameObject particleSpawn = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(particleSpawn, .5f);
            
            
        }
    }
}
