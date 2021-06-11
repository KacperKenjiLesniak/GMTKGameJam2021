using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BallRestarter : MonoBehaviour
    {
        private Vector3 initialPosition;

        private void Start()
        {
            initialPosition = transform.position;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.position = initialPosition;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().angularVelocity = 0f;
                GetComponent<TrailRenderer>().Clear();
            }
        }
    }
}