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

	public static void CreateCube(Vector3 pos)
	{
		GameObject cube = Instantiate(Resources.Load("GroundCube")) as GameObject;
		cube.transform.localScale = new Vector3(GridManager.tileSize, GridManager.tileSize, GridManager.tileSize);
		cube.transform.position = pos; //+ new Vector3(GridManager.tileSize/2.0f, GridManager.tileSize/2.0f, GridManager.tileSize/2.0f);
		groundCubes.Add(cube);
	}


	private void CreateGround()
	{
		float lastHeightChange = 0.0f;
		float heightChangeSpeed = 0.0f;
		for(float x = -size/2.0f; x < size / 2.0f; x += GridManager.tileSize)
		{
			for(float z = -size/2.0f; z < size / 2.0f; z += GridManager.tileSize)
			{
				float gridx = GridManager.GetCoord(x);
				float gridz = GridManager.GetCoord(z);
				CreateCube(new Vector3(gridx, groundHeightPos + lastHeightChange + Random.Range(-heightChangeSpeed, heightChangeSpeed), gridz));
			}
		}
	}
}
