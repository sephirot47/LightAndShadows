using UnityEngine;
using System.Collections;

public class BuiltLight : Buildable
{
    public Color colorWhenTargeted = new Color(1.0f, 0.0f, 0.0f);
    public float lightAttenuationWhenTargeted = 0.5f;
    private float originalIntensity;
    private Color originalColor;

    public override void Start()
    {
        base.Start();
        originalIntensity = GetComponent<Light>().intensity;
        originalColor = GetComponent<Light>().color;
        targetable = true;
        removableByPlayer = true;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnTargetEnters()
    {
        base.OnTargetEnters();
        GetComponent<Light>().intensity = originalIntensity * lightAttenuationWhenTargeted;
        GetComponent<Light>().color = colorWhenTargeted;
    }

    public override void OnTargetExits()
    {
        base.OnTargetExits();
        GetComponent<Light>().intensity = originalIntensity;
        GetComponent<Light>().color = originalColor;
    }

}
