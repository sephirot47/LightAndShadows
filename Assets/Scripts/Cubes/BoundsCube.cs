using UnityEngine;
using System.Collections;

public class BoundsCube : MonoBehaviour, ICube
{
	void Update () 
    {
        Transform player = Core.player;
        float d = Vector3.Distance(player.position, transform.position);
        if(d >= GridManager.tileSize * 4.0f)
        {
            Destroy(gameObject);
        }
	}

    public void OnTargetEnter() { }
    public void OnTargetExits() { }

    public bool IsRemovableByPlayer()
    {
        return false;
    }
}
