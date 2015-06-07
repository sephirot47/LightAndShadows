using UnityEngine;
using System.Collections;

public class PlayerSelectModeHandler : MonoBehaviour 
{
    private Player p;
    private Buildable targetedBuildable = null;

    void Start()
    {
        p = GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (p.currentMode == Player.Mode.SelectMode)
        {
            Buildable currentTargetedBuildable = GetTargetedBuildable();

            if (currentTargetedBuildable == null && targetedBuildable != null)
                targetedBuildable.GetComponent<Buildable>().OnTargetExits();

            if (currentTargetedBuildable != targetedBuildable)
            {
                if (targetedBuildable != null)
                {
                    targetedBuildable.OnTargetExits();
                    targetedBuildable = currentTargetedBuildable;
                }

                if (currentTargetedBuildable != null)
                {
                    currentTargetedBuildable.OnTargetEnters();
                }
            }


            if (Input.GetMouseButtonDown(1) && currentTargetedBuildable != null) //Elimina building
            {
                RemoveBuilding(currentTargetedBuildable.gameObject);
            }

            targetedBuildable = currentTargetedBuildable;
        }
        else if (targetedBuildable != null)
        {
            targetedBuildable.OnTargetExits();
            targetedBuildable = null;
        }
	}

    private Buildable GetTargetedBuildable()
    {
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 999.9f, Player.raycastLayer))
        {
            GameObject go = hit.collider.gameObject;
            return go.GetComponent<Buildable>();
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
