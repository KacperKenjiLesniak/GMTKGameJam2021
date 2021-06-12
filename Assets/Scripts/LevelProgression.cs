using System;
using EZCameraShake;
using GameEvents.Generic;
using GameEvents.Vector2;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour, IArgumentGameEventListener<Vector2>
{
    [SerializeField] private Vector2GameEvent levelCompleteEvent;
    [SerializeField] private float cameraMovementSpeed;
    [SerializeField] private float cameraZoomSpeed;

    private bool completed;
    private Camera camera;
    private Vector2 winLocation;
    private Vector3 cameraNewPosition;
    private float winTimer;
    
    private void Awake()
    {
        camera = Camera.main;
    }

    void Start()
    {
        levelCompleteEvent.RegisterListener(this);
    }

    public void RaiseGameEvent(Vector2 winLocation)
    {
        if (!completed)
        {
            completed = true;
            camera = Camera.main;
            cameraNewPosition = new Vector3(winLocation.x, winLocation.y, camera.transform.position.z);
            CameraShaker.Instance.StartShake(1, 2, 3);
        }
    }

    private void Update()
    {
        if (completed)
        {
            winTimer += Time.deltaTime;
            if (winTimer < 2f)
            {
                camera.transform.position = Vector3.Lerp(camera.transform.position, cameraNewPosition, winTimer*cameraMovementSpeed);
                camera.orthographicSize -= Time.deltaTime * cameraZoomSpeed;
            }
            if (winTimer > 3f)
            {
                int nextLevel = Int32.Parse(SceneManager.GetActiveScene().name.Replace("Level", "")) + 1;
                
                PlayerPrefs.SetInt("NextLevel", Mathf.Max(nextLevel, PlayerPrefs.GetInt("NextLevel", 1)));
                
                SceneManager.LoadScene("Level" + nextLevel);
            }
        }
    }
    
    
}