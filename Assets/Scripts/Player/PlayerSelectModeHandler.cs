using UnityEngine;
using System.Collections;

public class PlayerSelectModeHandler : MonoBehaviour 
{
    private Player p;
    void Start()
    {
        p = GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (p.currentMode == Player.Mode.SelectMode)
        {
            GameObject targetedBuilding = GetTargetedBuilding();
            
            //if (currentTargetedCube == null && targetedCube != null)
            //      targetedCube.OnTargetExits();

            // if (currentTargetedCube != null && currentTargetedCube != targetedCube)
            //   {
            //          if (targetedCube != null) targetedCube.OnTargetExits();
            //       currentTargetedCube.OnTargetEnter();
            //       targetedCube = currentTargetedCube;
            //    }


            if (Input.GetMouseButton(1) && targetedBuilding != null) //Elimina cubo
            {
                RemoveBuilding(targetedBuilding);
            }
        }
	}

    private GameObject GetTargetedBuilding()
    {
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 999.9f, Player.raycastLayer))
        {
            GameObject go = hit.collider.gameObject;
            if(go.GetComponent<Buildable>() != null) return go;
        }
        return null;
    }


    private void RemoveBuilding(GameObject go)
    {
        Buildable building = (Buildable) go.GetComponent( typeof(Buildable) );
        if(building != null)
        {
            if (building.IsRemovableByPlayer())
            {
                //if (building.gameObject == ) targetedCube = null;
                Destroy(go);
            }
        }
    }
}
