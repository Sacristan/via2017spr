using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

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

        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked; 
    }

    protected virtual void Update()
    {
        ApplyMovement();
        if (Input.GetKeyDown(KeyCode.Mouse0)) Shoot(); // if mouse 0 pressed -> shoot
    }

    #endregion

    #region Actions
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
