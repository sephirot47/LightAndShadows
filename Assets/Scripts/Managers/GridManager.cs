using UnityEngine;
using System.Collections;

public class GridManager
{
	public static float tileSize = 1.0f;
    public static Vector3 halfTileOffset = new Vector3(tileSize / 2.0f, tileSize / 2.0f, tileSize / 2.0f);

	public static float GetCoord(float a)
	{
		return Mathf.Floor(a / tileSize) * tileSize;
	}

	public static Vector3 GetPoint(Vector3 point)
	{
		Vector3 result = new Vector3();
        result.x = GetCoord(point.x);
		result.y = GetCoord(point.y);
        result.z = GetCoord(point.z);
		return result;
	}
}
