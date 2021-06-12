using System;
using GameEvents.Game;
using GameEvents.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class BallRestarter : MonoBehaviour, IGameEventListener
    {
        [SerializeField] private GameEvent restartLevel;

        private Vector3 initialPosition;

        private void Start()
        {
            initialPosition = transform.position;
            restartLevel.RegisterListener(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }

        public void Restart()
        {
            transform.position = initialPosition;
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            GetComponent<Rigidbody2D>().simulated = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0f;
            GetComponent<TrailRenderer>().Clear();
            GetComponent<BallScript>().dead = false;
        }

        public void RaiseGameEvent()
        {
            Restart();
        }

        private void OnDestroy()
        {
            restartLevel.UnregisterListener(this);
        }
    }
}