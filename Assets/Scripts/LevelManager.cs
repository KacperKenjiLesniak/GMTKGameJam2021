using System;
using GameEvents.Generic;
using GameEvents.Vector2;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace.Physiurg
{
    public class LevelManager : MonoBehaviour, IArgumentGameEventListener<Vector2>
    {
        [SerializeField] private Vector2GameEvent deathEvent;


        private void Start()
        {
            deathEvent.RegisterListener(this);
        }

        public void RaiseGameEvent(Vector2 argument)
        {
            Invoke(nameof(RestartLevel), 3f);
        }

        private void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnDestroy()
        {
            deathEvent.UnregisterListener(this);
        }
    }
}