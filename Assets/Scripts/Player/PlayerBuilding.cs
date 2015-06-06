using UnityEngine;
using System.Collections;

public class PlayerBuilding : MonoBehaviour 
{
    private enum BuildMode
    {
        SelectMode, PutCubeMode, PutLightReceiver, PutShadowReceiver
    };

    private GameObject sampleCube;
    private int raycastLayer;
    private ICube targetedCube = null;
    private BuildMode currentMode = BuildMode.SelectMode;

	void Start ()
    {
        raycastLayer = 1 << LayerMask.NameToLayer("Cubes");

        //Lo pongo tan arriba para asegurarme de que se puede poner y no se queja :)
        sampleCube = GroundManager.PutCube(GroundManager.CubeType.SampleCube, Vector3.zero + Vector3.up * 99);
        sampleCube.SetActive(false);
	}

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentMode = BuildMode.SelectMode;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) currentMode = BuildMode.PutCubeMode;

        ICube currentTargetedCube = GetTargetedCube();

        if (currentMode != BuildMode.PutCubeMode) sampleCube.SetActive(false);
        if(currentMode == BuildMode.PutCubeMode)
        {
            UpdateSampleCube();
		    if(Input.GetMouseButtonDown(0)) //Pon cubo
		    {
			    PutCube();
            }
        }
        else if(currentMode == BuildMode.SelectMode)
        {
            if (currentTargetedCube == null && targetedCube != null)
                targetedCube.OnTargetExits();

            if (currentTargetedCube != null && currentTargetedCube != targetedCube)
            {
                if (targetedCube != null) targetedCube.OnTargetExits();
                currentTargetedCube.OnTargetEnter();
                targetedCube = currentTargetedCube;
            }

		    if(Input.GetMouseButton(1)) //Elimina cubo
		    {
			    RemoveCube();
		    }
        }
	}

    private void UpdateSampleCube()
    {
		Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 999.9f, raycastLayer))
        {
            Vector3 cubePos = hit.point + hit.normal * 0.1f;
            sampleCube.transform.position = GridManager.GetPoint(cubePos);
            sampleCube.transform.position += GridManager.halfTileOffset;
            sampleCube.SetActive(true);
        }
        else sampleCube.SetActive(false);
    }

    private ICube GetTargetedCube()
    {
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 999.9f, raycastLayer))
        {
            GameObject go = hit.collider.gameObject;
            ICube cube = (ICube)go.GetComponent(typeof(ICube));
            if (cube != null) return cube;
        }
        return null;
    }

	private void PutCube()
	{
		Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 999.9f, raycastLayer))
		{
            Vector3 cubePos = hit.point + hit.normal * 0.1f;
            GroundManager.PutCube(GroundManager.CubeType.BuiltCube, cubePos);
		}
	}

	private void RemoveCube()
	{
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 999.9f, raycastLayer))
        {
            GameObject go = hit.collider.gameObject;
            ICube cube = (ICube) go.GetComponent( typeof(ICube) );
            if(cube != null)
            {
                if (cube.IsRemovableByPlayer())
                {
                    if (cube == targetedCube) targetedCube = null;
                    Destroy(go);
                }
            }
		}
	}
}
