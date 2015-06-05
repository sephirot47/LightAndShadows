using UnityEngine;
using System.Collections;

public class GroundCube : MonoBehaviour
{

	void Start () 
	{
        float lum = Random.Range(0.9f, 1.0f);
        GetComponent<Renderer>().material.color = new Color(lum, lum, lum);
    }
	
	void Update () 
    {
        
	}

    public bool IsRemovableByPlayer()
    {
        return false;
    }
}
