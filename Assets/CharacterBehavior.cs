using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehavior : MonoBehaviour {

	private CharacterController characterController;
		
	[SerializeField]
	private float speed = 5f;

	[SerializeField]
	private float horizontalRotationSpeed = 200f;
	[SerializeField]
	private float verticalRotationSpeed = 200f;

	[SerializeField]
	private GameObject bulletPrefab;

	[SerializeField]
	private Transform bulletSpawnTransform;

	void Start () {
		characterController = GetComponent<CharacterController> ();
	}
	
	void Update () {
		float horizontalInput = Input.GetAxis ("Horizontal");	
		float verticalInput = Input.GetAxis ("Vertical");

		float h = horizontalRotationSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
		float v = verticalRotationSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
	
		Vector3 inputForMovement = new Vector3 (horizontalInput, 0, verticalInput);

		Vector3 deltaInput = inputForMovement * Time.deltaTime * speed;
		deltaInput.y = Physics.gravity.y;

		transform.Rotate(-v, h, 0);
		characterController.Move (deltaInput);

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Instantiate (bulletPrefab, bulletSpawnTransform.position, Quaternion.identity);
		}
	}
}
