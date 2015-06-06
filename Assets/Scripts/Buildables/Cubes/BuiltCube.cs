using UnityEngine;
using System.Collections;

public class BuiltCube : Buildable
{
    public override void Start()
    {
        base.Start();
        targetable = true;
        removableByPlayer = true;
	}

	public override void Update ()
    {
        base.Update();
	}

    public override void OnTargetEnters()
    {
        base.OnTargetEnters();
    }

    public override void OnTargetExits()
    {
        base.OnTargetExits();
    }

}
