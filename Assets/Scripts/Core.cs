using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour
{
    public static Transform player;

	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update () {
	
	}
}
