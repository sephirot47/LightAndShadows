using UnityEngine;
using System.Collections;

public class PlayerBuilding : MonoBehaviour {

	void Start () {
	
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(1)) //Elimina cubo
		{
			DestroyTargetCube();
		}
		else if(Input.GetMouseButtonDown(0)) //Pon cubo
		{
			PutCube();
		}
		else
		{
			PutSampleCube();
		}
	}

	private void PutSampleCube()
	{
	}

	private void PutCube()
	{
		Ray ray = new Ray (transform.position, Camera.main.transform.forward);
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(ray, out hit, 100.9f))
		{
			Vector3 cubePos = hit.point + hit.normal * 0.5f;
			Vector3 gridedPos = GridManager.GetPoint(cubePos);
			Debug.Log ("REAL: " + cubePos + ", GRIDED: " + gridedPos);
			Debug.DrawLine(transform.position, hit.point, Color.green, 999.0f, false);
			GroundManager.CreateCube(gridedPos);
		}
	}

	private void DestroyTargetCube()
	{
		Ray ray = new Ray (transform.position, Camera.main.transform.forward);
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(ray, out hit, 100.9f))
		{
			Destroy(hit.collider.gameObject);
		}
	}
}
