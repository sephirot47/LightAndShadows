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
	
    public void OnModeChanged()
    {
        if (currentBuilding != null) Destroy(currentBuilding);
        currentBuilding = null;
    }

	void Update () 
    {
        if (p.currentMode != Player.Mode.PutCubeMode && p.currentMode != Player.Mode.PutLightMode)
        {
            return;
        }

        if (currentBuilding == null)
        {
            BuildingsManager.BuildingType buildingType = BuildingsManager.BuildingType.BuiltCube;
            if (p.currentMode == Player.Mode.PutCubeMode) buildingType = BuildingsManager.BuildingType.BuiltCube;
            else if (p.currentMode == Player.Mode.PutLightMode) buildingType = BuildingsManager.BuildingType.BuiltLight;

            currentBuilding = PutBuilding(buildingType);

            if(currentBuilding != null)
                currentBuilding.GetComponent<Buildable>().OnBuildingStarted();
        }

        UpdateCurrentBuildingPosition();

        if (Input.GetMouseButtonDown(0) && currentBuilding != null) //Pon building
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

    private GameObject PutBuilding(BuildingsManager.BuildingType buildingType)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 999.9f, Player.raycastLayer))
        {
            Vector3 cubePos = hit.point + hit.normal * 0.1f;
            return BuildingsManager.PutBuilding(buildingType, cubePos);
        }
        return null;
    }
}
