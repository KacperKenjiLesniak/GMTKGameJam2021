using System;
using System.Collections.Generic;
using System.Linq;
using EZCameraShake;
using GameEvents.Game;
using GameEvents.Generic;
using GameEvents.Vector2;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace.Physiurg
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Vector2GameEvent deathEvent;
        [SerializeField] private GameEvent restartLevel;

        private List<Rigidbody2D> balls;

        private void Awake()
        {
            balls = GameObject.FindGameObjectsWithTag("Ball").Select(g => g.GetComponent<Rigidbody2D>()).ToList();
        }

        private void Start()
        {
            balls.ForEach(b => b.simulated = false);
        }

        public void StartGame()
        {
            balls.ForEach(b => b.simulated = true);
        }

        public void BallDied(Vector2 argument)
        {
            restartLevel.RaiseGameEvent();
            CameraShaker.Instance.ShakeOnce(1, 5, 0.5f, 0.5f);
        }
    }
}