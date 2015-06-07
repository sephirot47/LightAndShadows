using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public enum Mode
    {
        SelectMode, PutCubeMode, PutLightMode
    };

    public Mode currentMode = Mode.SelectMode;

    public static int raycastLayer;

	void Update ()
    {
        Mode lastMode = currentMode;
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentMode = Mode.SelectMode;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) currentMode = Mode.PutCubeMode;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) currentMode = Mode.PutLightMode;
        if (currentMode != lastMode) GetComponent<PlayerBuildModeHandler>().OnModeChanged();
    }
}
