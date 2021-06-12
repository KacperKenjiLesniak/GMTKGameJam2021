using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallGravityManipulator : PhysicManipulator
{
    public List<Rigidbody2D> rbs;

    protected override void Start()
    {
        base.Start();
        rbs = GameObject.FindGameObjectsWithTag("Ball").Select(o => o.GetComponent<Rigidbody2D>()).ToList();
        rbs.ForEach(rb => rb.gravityScale = currentValue);
    }

    protected override void UpdatePhysicProperty()
    {
        rbs.ForEach(rb => rb.gravityScale = currentValue);
    }
}