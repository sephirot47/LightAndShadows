using UnityEngine;
using System.Collections;

public class GroundCube : MonoBehaviour
{
	void Start () 
	{
		GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
	
	void Update () 
    {
        
	}
}
