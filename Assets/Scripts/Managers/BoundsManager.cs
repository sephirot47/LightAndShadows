using UnityEngine;
using System.Collections;

public class BoundsManager : MonoBehaviour
{
	void Start () 
    {
	
	}
	
	void Update () 
    {
        return;

        Transform player = Core.player;

	    for(float x = -GridManager.tileSize; x <= GridManager.tileSize; ++x)
        {
            for (float z = -GridManager.tileSize; z <= GridManager.tileSize; ++z)
            {
                Vector3 pos = new Vector3(x + player.transform.position.x, 
                                          GroundManager.groundHeightPos,
                                          z + player.transform.position.z);
                GroundManager.PutCube(GroundManager.CubeType.BoundsCube, pos);
            }
        }
	}
}
