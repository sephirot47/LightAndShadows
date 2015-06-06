using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private CharacterController controller;

	public Vector3 rotation;
	public float rotationSpeedHorizontal = 400.0f, rotationSpeedVertical = 300.0f, 
				 rotationVerticalLimitMin = -89.0f, rotationVerticalLimitMax = 89.0f;
    public float movementSpeedMax = 14.0f, movementAcc = 0.25f;
    public float floatingSpeedMax = 0.25f, floatingAcc = 0.01f;

    private float movementSpeed = 0.0f, floatingSpeed = 0.0f;

	void Start () 
	{
		controller = GetComponent<CharacterController>();
	}
	
	void Update ()
    {
        float mousex = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeedHorizontal;
        float mousey = Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeedVertical;
        rotation += new Vector3(-mousey, mousex, 0.0f);
        rotation.x = Mathf.Clamp(rotation.x, rotationVerticalLimitMin, rotationVerticalLimitMax);
        transform.rotation = Quaternion.Euler(rotation);

        if (Input.GetKey(KeyCode.Q)) floatingSpeed += floatingAcc;
        else if (Input.GetKey(KeyCode.E)) floatingSpeed -= floatingAcc;
        else floatingSpeed = 0.0f;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x == 0.0f && y == 0.0f) movementSpeed = 0.0f;
        else movementSpeed += movementAcc;

        movementSpeed = Mathf.Clamp(movementSpeed, -movementSpeedMax, movementSpeedMax);
        floatingSpeed = Mathf.Clamp(floatingSpeed, -floatingSpeedMax, floatingSpeedMax);

        Vector3 movement = Vector3.zero;
        movement += transform.right * x * Time.deltaTime * movementSpeed;
        movement += transform.forward * y * Time.deltaTime * movementSpeed;
        movement += Vector3.up * floatingSpeed;
        
		controller.Move(movement);
	}

	private Vector3 PlaneVector(Vector3 v)
	{
		return new Vector3 (v.x, 0.0f, v.z);
	}
}
