using System.Collections;
using System.Collections.Generic;
using GameEvents.Generic;
using GameEvents.Vector2;
using UnityEngine;

public class LevelCompleteParticleEffect : MonoBehaviour, IArgumentGameEventListener<Vector2>
{
    [SerializeField] private Vector2GameEvent levelCompleteEvent;

    private bool played;
    
    void Start()
    {
        levelCompleteEvent.RegisterListener(this);
    }

    public void RaiseGameEvent(Vector2 winLocation)
    {
        if (!played)
        {
            played = true;
            transform.position = winLocation;
            GetComponent<ParticleSystem>().Play();
        }
    }
}
