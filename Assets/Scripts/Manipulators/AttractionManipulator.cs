using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttractionManipulator : PhysicManipulator
{
    public List<BallScript> ballScripts;

    protected override void Start()
    {
        base.Start();
        ballScripts = GameObject.FindGameObjectsWithTag("Ball").Select(o => o.GetComponent<BallScript>()).ToList();
        ballScripts.ForEach(bs => bs.connectionForce = currentValue);
    }

    protected override void UpdatePhysicProperty()
    {
        ballScripts.ForEach(bs => bs.connectionForce = currentValue);
    }
}