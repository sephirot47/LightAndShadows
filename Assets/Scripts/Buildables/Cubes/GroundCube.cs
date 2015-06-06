using UnityEngine;
using System.Collections;

public class GroundCube : MonoBehaviour
{
    public bool rayDebug = false;

    private int raycastLayer;

	public void Start ()
    {
        float lum = Random.Range(0.8f, 0.9f);
        GetComponent<Renderer>().material.color = new Color(lum, lum, lum);

        raycastLayer = 1 << LayerMask.NameToLayer("Cubes");
    }

    public void Update()
    {
        bool receivingLight = ReceivesAnyLight();

        if ( receivingLight )
        {
            //GOOD
          //  Debug.DrawRay(transform.position, Vector3.up, Color.green, 0.1f, true);
        }
        else
        {
            //BAD
         //   Debug.DrawRay(transform.position, Vector3.up, Color.red, 0.1f, true);
        }
	}

    public bool ReceivesAnyLight()
    {
        Light[] lights = GameObject.FindObjectsOfType<Light>();
        foreach(Light light in lights)
        {
            if (ReceivesLightFrom(light.gameObject)) return true;
        }
        return false;
    }
    
    public bool ReceivesLightFrom(GameObject lightGameObject)
    {
        //Miramos si esta iluminada la parte superior del cubo
        Light light = lightGameObject.GetComponent<Light>();

        Vector3 origin = transform.position + Vector3.up * GridManager.tileSize * 0.5f;
        Vector3 dir = Vector3.up;

        if(light.type == LightType.Directional)
            dir = -light.transform.forward;
        else
            dir = lightGameObject.transform.position - origin;

        Ray ray = new Ray(origin, dir);
        RaycastHit hit = new RaycastHit();

        if (rayDebug)
            Debug.DrawRay(ray.origin, ray.origin + ray.direction * 9999.9f, Color.green, 0.1f, true);

        if(light.type == LightType.Directional)
            return !Physics.Raycast(ray, out hit, 99999.9f, raycastLayer);
        else 
            return !Physics.Raycast(ray, out hit, dir.magnitude, raycastLayer);
    }
}
