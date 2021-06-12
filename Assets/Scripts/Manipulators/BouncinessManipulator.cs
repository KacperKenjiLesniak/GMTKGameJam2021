using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BouncinessManipulator : PhysicManipulator
{
    public PhysicsMaterial2D ballMaterial;
    public List<Collider2D> ballColliders;

    protected override void Start()
    {
        base.Start();
        ballColliders = GameObject.FindGameObjectsWithTag("Ball").Select(o => o.GetComponent<Collider2D>()).ToList();
        ballMaterial.bounciness = currentValue;
        ballColliders.ForEach(c => c.enabled = false);
        ballColliders.ForEach(c => c.enabled = true);
    }

    protected override void UpdatePhysicProperty()
    {
        if (Math.Abs(ballMaterial.bounciness - currentValue) > 0.01f)
        {
            ballMaterial.bounciness = currentValue;
            ballColliders.ForEach(c => c.enabled = false);
            ballColliders.ForEach(c => c.enabled = true);
        }
    }
}