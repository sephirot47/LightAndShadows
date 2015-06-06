using UnityEngine;
using System.Collections;

public class BuiltCube : MonoBehaviour, ICube
{
    public Color targetedColor = new Color(0.5f, 0.5f, 0.5f);
    private Color originalColor;
	
    void Start () 
    {
        originalColor = GetComponent<Renderer>().material.color;
	}

	void Update () 
    {
	    
	}

    public void OnTargetEnter()
    {
        GetComponent<Renderer>().material.color = targetedColor;
    }

    public void OnTargetExits()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    public bool IsRemovableByPlayer()
    {
        return true;
    }
}
