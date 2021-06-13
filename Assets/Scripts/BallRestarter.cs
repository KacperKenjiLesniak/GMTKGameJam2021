using System;
using GameEvents.Game;
using GameEvents.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class BallRestarter : MonoBehaviour
    {
        [SerializeField] private GameEvent restartLevel;

        private Vector3 initialPosition;

        private void Start()
        {
            initialPosition = transform.position;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                restartLevel.RaiseGameEvent();
            }
        }

        public void Restart()
        {
            transform.position = initialPosition;
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0f;
            GetComponent<TrailRenderer>().Clear();
            GetComponent<BallScript>().dead = false;
        }

        public void RestartDelayed()
        {
            if (!IsInvoking(nameof(Restart)))
            {
                Invoke(nameof(SendRestartEvent), 3f);
            }
        }

        public void RestartNotDelayed()
        {
            if (!IsInvoking(nameof(Restart)))
            {
                Restart();
            }
        }
        
        private void SendRestartEvent()
        {
            restartLevel.RaiseGameEvent();
        }

    }
}