using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public enum Mode
    {
        SelectMode, PutCubeMode, PutLightReceiver, PutShadowReceiver
    };

    public Mode currentMode = Mode.SelectMode;

    public static int raycastLayer;

	void Start ()
    {
        //Lo pongo tan arriba para asegurarme de que se puede poner y no se queja :)
        //sampleCube = BuildingsManager.PutCube(BuildingsManager.BuildingType.SampleCube, Vector3.zero + Vector3.up * 99);
        //sampleCube.SetActive(false);
	}

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentMode = Mode.SelectMode;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) currentMode = Mode.PutCubeMode;
	}

    /*
    private void UpdateSampleCube()
    {
    }
    */

}
