using UnityEngine;
using System.Collections;

public class GridManager
{
	public static float tileSize = 1.0f;

	public static float GetCoord(float a)
	{
		return ((int) a ) / tileSize * tileSize + tileSize/2.0f;
	}

	public static Vector3 GetPoint(Vector3 point)
	{
		Vector3 result = new Vector3();
		result.x = GetCoord(point.x);
		result.y = GetCoord(point.y);
		result.z = GetCoord(point.z);
		Debug.DrawLine(result, result + Vector3.up, Color.red, 9999.9f, false);
		return result;
	}
}
