using System;
using EZCameraShake;
using GameEvents.Generic;
using GameEvents.Vector2;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour, IArgumentGameEventListener<Vector2>
{
    [SerializeField] private Vector2GameEvent levelCompleteEvent;

    private bool completed;
    private Vector2 winLocation;
    private float winTimer;
    

    void Start()
    {
        levelCompleteEvent.RegisterListener(this);
    }

    public void RaiseGameEvent(Vector2 winLocation)
    {
        if (!completed)
        {
            completed = true;
            CameraShaker.Instance.ShakeOnce(2, 10, 1f, 3f);
        }
    }

    private void Update()
    {
        if (completed)
        {
            winTimer += Time.deltaTime;

            if (winTimer > 2f)
            {
                int nextLevel = Int32.Parse(SceneManager.GetActiveScene().name.Replace("Level", "")) + 1;
                
                PlayerPrefs.SetInt("NextLevel", Mathf.Max(nextLevel, PlayerPrefs.GetInt("NextLevel", 1)));

                Debug.Log("Level" + nextLevel);
                Debug.Log(SceneManager.GetSceneByName("Level" + nextLevel));
                Debug.Log(SceneManager.GetSceneByName("Level" + nextLevel).IsValid());
                if (Application.CanStreamedLevelBeLoaded("Level" + nextLevel))
                {
                    SceneManager.LoadScene("Level" + nextLevel);
                }
                else
                {
                    SceneManager.LoadScene("Win");
                }
            }
        }
    }
    
    
}