using System;
using System.Collections;
using System.Collections.Generic;
using GameEvents.Vector2;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] public float connectionForce;
    
    [SerializeField] private Transform secondBall;
    [SerializeField] private Transform fragmentedBall;
    [SerializeField] private Vector2GameEvent levelCompleteEvent;
    [SerializeField] private Vector2GameEvent deathEvent;
    
    private Rigidbody2D rb;
    private ExplosionForce explosionForce;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        explosionForce = fragmentedBall.GetComponent<ExplosionForce>();
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
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;
            Debug.Log("Level complete");
        }
        
        if (other.gameObject.CompareTag("Spikes"))
        {
            deathEvent.RaiseGameEvent(other.GetContact(0).point);
            fragmentedBall.gameObject.SetActive(true);
            fragmentedBall.parent = transform.parent;
            explosionForce.Explode();
            Debug.Log("Level lost");
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;
        }
    }
}
