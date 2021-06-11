using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DensityManipulator : PhysicManipulator
{
    private List<BuoyancyEffector2D> buoyancyEffectors;

    protected override void Start()
    {
        base.Start();
        buoyancyEffectors = GameObject.FindGameObjectsWithTag("Water")
            .Select(g => g.GetComponent<BuoyancyEffector2D>()).ToList();
    }

    protected override void UpdatePhysicProperty()
    {
        buoyancyEffectors.ForEach(effector => effector.density = currentValue);
    }
}