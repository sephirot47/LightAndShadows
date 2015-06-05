using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	[SerializeField]
	private static float gravity = -5.0f;

	private float speedY = 0.0f;
	private CharacterController controller;

	public Vector3 rotation;
	public float rotationSpeedHorizontal = 100.0f, rotationSpeedVertical = 45.0f, 
				 rotationVerticalLimitMin = -45.0f, rotationVerticalLimitMax = 45.0f;
	public float movementSpeed = 5.0f;
	public float jumpForce = 5.0f;

	void Start () 
	{
		controller = GetComponent<CharacterController>();
	}
	
	void Update () 
	{
		float mousex = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeedHorizontal;
		float mousey = Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeedVertical;
		rotation += new Vector3(-mousey, mousex, 0.0f);
		rotation.x = Mathf.Clamp (rotation.x, rotationVerticalLimitMin, rotationVerticalLimitMax);
		Camera.main.transform.rotation = Quaternion.Euler(rotation);

		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		speedY += gravity;
		if(controller.isGrounded) speedY = 0.0f;

		Vector3 movement = Vector3.zero;
		movement += ( PlaneVector(Camera.main.transform.forward) * y).normalized * Time.deltaTime * movementSpeed;
		movement += ( PlaneVector(Camera.main.transform.right)   * x).normalized * Time.deltaTime * movementSpeed;
		movement += new Vector3(0, speedY, 0);
		controller.Move(movement);
	}

	private Vector3 PlaneVector(Vector3 v)
	{
		return new Vector3 (v.x, 0.0f, v.z);
	}
}
