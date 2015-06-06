using UnityEngine;
using System.Collections;

public class PlayerBuildModeHandler : MonoBehaviour 
{
    private Player p;

    private GameObject currentBuilding = null;

	void Start ()
    {
        Player.raycastLayer = 1 << LayerMask.NameToLayer("Cubes");
        p = GetComponent<Player>();
	}
	
	void Update () 
    {
        if (p.currentMode != Player.Mode.PutCubeMode)
        {
            if (currentBuilding != null)
            {
                Destroy(currentBuilding);
            }
            return;
        }

        if (currentBuilding == null)
        {
            currentBuilding = PutCube();
            if(currentBuilding != null)
                currentBuilding.GetComponent<Buildable>().OnBuildingStarted();
        }

        UpdateCurrentBuildingPosition();

        if (Input.GetMouseButtonDown(0) && currentBuilding != null) //Pon cubo
        {
            currentBuilding.GetComponent<Buildable>().OnBuildingFinished();
            currentBuilding = null;
        }
	}

    private void UpdateCurrentBuildingPosition()
    {
        if (currentBuilding == null) return;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 999.9f, Player.raycastLayer))
        {
            Vector3 cubePos = hit.point + hit.normal * 0.1f;
            currentBuilding.transform.position = GridManager.GetPoint(cubePos);
            currentBuilding.transform.position += GridManager.halfTileOffset;
            currentBuilding.SetActive(true);
        }
        else currentBuilding.SetActive(false);
    }

    private GameObject PutCube()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 999.9f, Player.raycastLayer))
        {
            Vector3 cubePos = hit.point + hit.normal * 0.1f;
            return BuildingsManager.PutCube(BuildingsManager.BuildingType.BuiltCube, cubePos);
        }
        return null;
    }
}
