using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Transform secondBall;
    [SerializeField] private float connectionForce;
    
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddForce((secondBall.position-transform.position) * (connectionForce * Time.deltaTime));        
    }
}
