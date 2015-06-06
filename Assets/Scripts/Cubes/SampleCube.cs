using UnityEngine;
using System.Collections;

public class SampleCube : MonoBehaviour, ICube
{

	void Start () {
	
	}
	
	void Update () {
	
	}


    public void OnTargetEnter() { }
    public void OnTargetExits() { }
    public bool IsRemovableByPlayer() { return false; }
}
