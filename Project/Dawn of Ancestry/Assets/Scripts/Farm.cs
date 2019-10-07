using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Resource
{
    [SerializeField] private Construction construction;

    protected override void Update()
    {
        if (construction.IsBuilt)
        {
            base.Update();
        }
    }
}
