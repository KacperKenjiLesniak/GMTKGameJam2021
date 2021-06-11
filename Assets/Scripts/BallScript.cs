using System;
using System.Collections;
using System.Collections.Generic;
using GameEvents.Vector2;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Transform secondBall;
    [SerializeField] private float connectionForce;
    [SerializeField] private Vector2GameEvent levelCompleteEvent;
    
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddForce((secondBall.position-transform.position) * (connectionForce * Time.deltaTime));        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            levelCompleteEvent.RaiseGameEvent(other.GetContact(0).point);
            Debug.Log("Level complete");
        }
    }
}
