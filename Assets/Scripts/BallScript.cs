using System;
using System.Collections;
using System.Collections.Generic;
using GameEvents.Vector2;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float connectionForce;
    public bool dead;

    [SerializeField] private Transform secondBall;
    [SerializeField] private Transform fragmentedBall;
    [SerializeField] private Vector2GameEvent levelCompleteEvent;
    [SerializeField] private Vector2GameEvent deathEvent;

    private Rigidbody2D rb;
    private ExplosionForce explosionForce;
    private GameObject fragmentedBallClone;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddForce((secondBall.position - transform.position) * (connectionForce * Time.deltaTime));
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
            if (!dead)
            {
                dead = true;
                deathEvent.RaiseGameEvent(other.GetContact(0).point);

                fragmentedBallClone = Instantiate(fragmentedBall.gameObject, fragmentedBall.transform.position,
                    fragmentedBall.transform.rotation, transform);
                fragmentedBallClone.gameObject.SetActive(true);
                explosionForce = fragmentedBallClone.GetComponent<ExplosionForce>();
                fragmentedBallClone.transform.parent = transform.parent;
                explosionForce.Explode();

                Invoke(nameof(DestroyFragments), 3f);

                Debug.Log("Level lost");
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Rigidbody2D>().simulated = false;
            }
        }
    }

    private void DestroyFragments()
    {
        Destroy(fragmentedBallClone);
    }
}