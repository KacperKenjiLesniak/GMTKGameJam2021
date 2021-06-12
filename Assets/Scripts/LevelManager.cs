using System;
using EZCameraShake;
using GameEvents.Game;
using GameEvents.Generic;
using GameEvents.Vector2;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace.Physiurg
{
    public class LevelManager : MonoBehaviour, IArgumentGameEventListener<Vector2>
    {
        [SerializeField] private Vector2GameEvent deathEvent;
        [SerializeField] private GameEvent restartLevel;


        private void Start()
        {
            deathEvent.RegisterListener(this);
        }

        public void RaiseGameEvent(Vector2 argument)
        {
            Invoke(nameof(RestartLevel), 3f);
            CameraShaker.Instance.ShakeOnce(1, 5, 0.5f, 0.5f);
        }

        private void RestartLevel()
        {
            restartLevel.RaiseGameEvent();
        }

        private void OnDestroy()
        {
            deathEvent.UnregisterListener(this);
        }
    }
}