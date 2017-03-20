using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehavior : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float mouseSensitivity = 50f;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform bulletSpawnTransform;

    private CharacterController characterController;

    #region MonoBehaviour Methods

    protected virtual void Start()
    {
        //Cache CharacterController component
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked; //Lock cursor
    }

    protected virtual void Update()
    {
        ApplyRotation();
        ApplyMovement();
        if (Input.GetKeyDown(KeyCode.Mouse0)) Shoot(); // if mouse 0 pressed -> shoot
    }

    #endregion

    #region Actions
    private void ApplyRotation()
    {
        //Rotation Input
        float yaw = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        Quaternion cameraRotation = Quaternion.Euler(0, yaw, 0);

        //Apply rotation
        transform.rotation *= cameraRotation;
    }
    private void ApplyMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput); //input direction
        Vector3 movementDirection = transform.TransformDirection(inputDirection); //convert vector direction to local space direction

        Vector3 velocity = movementDirection * speed * Time.deltaTime; //Velocity -> movement direction with speed and deltaTime
        velocity += Physics.gravity * Time.deltaTime; //Apply Gravity with deltaTime

        characterController.Move(velocity); //Apply delta Velocity that is specific to this frame
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnTransform.position, transform.rotation);
    }
    #endregion
}
