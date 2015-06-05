using UnityEngine;
using System.Collections;

public class PlayerBuilding : MonoBehaviour {

	void Start () {
	
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(1)) //Elimina cubo
		{
			RemoveCube();
		}
		else if(Input.GetMouseButtonDown(0)) //Pon cubo
		{
			PutCube();
		}
	}

	private void PutCube()
	{
		Ray ray = new Ray (transform.position, Camera.main.transform.forward);
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(ray, out hit, 100.9f))
		{
			Vector3 cubePos = hit.point + hit.normal * 0.1f;
			GroundManager.CreateBuiltCube(cubePos);
		}
	}

	private void RemoveCube()
	{
		Ray ray = new Ray (transform.position, Camera.main.transform.forward);
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(ray, out hit, 100.9f))
        {
            GameObject go = hit.collider.gameObject;
            ICube cube = (ICube) go.GetComponent( typeof(ICube) );
            if(cube != null)
            {
                if (cube.IsRemovableByPlayer())
                {
                    Destroy(go);
                }
            }
		}
	}
}
