using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    [SerializeField] float rotationSpeed;

    [SerializeField] float zBound;

    [SerializeField] float jumpSpeed;
    [SerializeField] float ySpeed;
    private CharacterController characterController;
    private float originalStepOffset;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.stepOffset = originalStepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
    }

    void PlayerControls()
    {
        // Player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        PlayerJump();


        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        Vector3 speed1 = movementDirection * speed;
        speed1.y = ySpeed;
        characterController.Move(speed1 * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }


    }

    void PlayerJump()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;

            ySpeed = -0.5f;
            if (Input.GetButton("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            originalStepOffset = 0;
        }
    }


}
