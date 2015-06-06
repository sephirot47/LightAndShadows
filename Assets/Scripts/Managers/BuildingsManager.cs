using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingsManager : MonoBehaviour 
{
    public enum BuildingType
    {
        GroundCube, BuiltCube
    };

	public static float groundHeightPos = 0.0f;
	public static float size = 15.0f;
	private static List<GameObject> groundCubes;

	void Start () 
	{
		groundCubes = new List<GameObject>();
		CreateGround();
	}

	void Update () 
	{
	}

    public static GameObject PutCube(BuildingType buildingType, Vector3 pos)
    {
        if (!CanPutCube(pos)) return null;

        string resName = GetCubeTypeResourceName(buildingType);
        GameObject cube = Instantiate(Resources.Load(resName)) as GameObject;
        if (buildingType == BuildingType.GroundCube) groundCubes.Add(cube);

		cube.transform.localScale = new Vector3(GridManager.tileSize, GridManager.tileSize, GridManager.tileSize);

        Vector3 gridedPos = GridManager.GetPoint(pos);
        gridedPos += GridManager.halfTileOffset;
        cube.transform.position = gridedPos;
        return cube;
    }

    private static string GetCubeTypeResourceName(BuildingType buildingType)
    {
        switch (buildingType)
        {
            case BuildingType.GroundCube: return "GroundCube";
            case BuildingType.BuiltCube: return "BuiltCube";
        }

        return "BuiltCube";
    }

    private static bool CanPutCube(Vector3 pos)
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
                Vector3 pos = new Vector3(x, groundHeightPos, z);
                PutCube(BuildingType.GroundCube, pos);
			}
		}
	}
}
