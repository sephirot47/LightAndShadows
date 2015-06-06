using UnityEngine;
using System.Collections;

public class Buildable : MonoBehaviour
{
    public Color targetedColor = new Color(0.5f, 0.5f, 0.5f);
    private Color originalColor;

    public Material buildingMaterial = null;
    public Material originalMaterial = null;

    protected bool targetable = false;
    protected bool removableByPlayer = false;

    public virtual void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
    }

    public virtual void Update()
    {

    }

    public virtual void OnBuildingStarted() //Cuando el building se esta colocando
    {
        if (buildingMaterial != null) GetComponent<Renderer>().material = buildingMaterial;
        GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        Collider[] colls = GetComponents<Collider>();
        foreach(Collider col in colls) col.enabled = false;
    }

    public virtual void OnBuildingFinished() //Cuando el building se ha puesto
    {
        GetComponent<Renderer>().material = originalMaterial;
        GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;

        Collider[] colls = GetComponents<Collider>();
        foreach (Collider col in colls) col.enabled = true;
    }

    public virtual void OnTargetEnters()
    {
        if (targetable)
            GetComponent<Renderer>().material.color = targetedColor;
    }

    public virtual void OnTargetExits()
    {
        if (targetable)
            GetComponent<Renderer>().material.color = originalColor;
    }

    public bool IsRemovableByPlayer()
    {
        return removableByPlayer;
    }
}