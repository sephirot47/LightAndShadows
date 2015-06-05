using UnityEngine;
using System.Collections;

public class GridManager
{
	public static float tileSize = 1.0f;

	public static Vector3 GetPoint(Vector3 point)
	{
		Vector3 result = new Vector3();
		result.x = ((int)point.x) / tileSize * tileSize;
		result.y = ((int)point.y) / tileSize * tileSize;
		result.z = ((int)point.z) / tileSize * tileSize;
		return result;
	}
}
