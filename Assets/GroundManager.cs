using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundManager : MonoBehaviour 
{
	public static float groundHeightPos = 0.0f;
	public static float size = 30.0f;
	private static List<GameObject> groundCubes;

	void Start () 
	{
		groundCubes = new List<GameObject>();
		CreateGround();
	}

	void Update () 
	{
	}

    private static GameObject BuildCube(GameObject cube, Vector3 pos)
    {
		cube.transform.localScale = new Vector3(GridManager.tileSize, GridManager.tileSize, GridManager.tileSize);

        Vector3 gridedPos = GridManager.GetPoint(pos);
        gridedPos += GridManager.halfTileOffset;
        cube.transform.position = gridedPos;

		groundCubes.Add(cube);
        return cube;
    }

	public static GameObject CreateGroundCube(Vector3 pos)
	{
        if (!CanBuildCube(pos)) return null;
		GameObject cube = Instantiate(Resources.Load("GroundCube")) as GameObject;
        return BuildCube(cube, pos);
	}

    public static GameObject CreateBoundsCube(Vector3 pos)
    {
        if (!CanBuildCube(pos)) return null;
        GameObject cube = Instantiate(Resources.Load("BoundsCube")) as GameObject;
        return BuildCube(cube, pos);
    }

    public static GameObject CreateBuiltCube(Vector3 pos)
    {
        if (!CanBuildCube(pos)) return null;
        GameObject cube = Instantiate(Resources.Load("BuiltCube")) as GameObject;
        return BuildCube(cube, pos);
    }


    private static bool CanBuildCube(Vector3 pos)
    {
        Vector3 centeredInGridTilePos = GridManager.GetPoint(pos) + GridManager.halfTileOffset;
        return !Physics.CheckSphere(centeredInGridTilePos, GridManager.tileSize * 0.49f);
    }

	private void CreateGround()
	{
		for(float x = -size/2.0f; x < size / 2.0f; x += GridManager.tileSize)
		{
			for(float z = -size/2.0f; z < size / 2.0f; z += GridManager.tileSize)
			{
                Vector3 pos = GridManager.GetPoint( new Vector3(x, groundHeightPos, z) );
                pos += GridManager.halfTileOffset;
                CreateGroundCube(pos);
			}
		}
	}
}
