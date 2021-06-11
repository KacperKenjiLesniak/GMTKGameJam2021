using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Physiurg;
using GameEvents.Vector2;
using UnityEngine;

public class ExplosionForce : MonoBehaviour
{

    public Transform explosionPoint;
    public float explosionForce = 10f;
    public float explosionRadius = 10f;
    
    public void Explode()
    {
        foreach (var rb in GetComponentsInChildren<Rigidbody2D>())
        {
            Debug.Log("Exploding!");
            rb.AddExplosionForce(explosionForce, explosionPoint.position, explosionRadius);
        }
    }
}
