using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool gameOver = false;

    [SerializeField] float rotationSpeed;

    private float zBoundUp = 90.0f;
    private float zBoundDown = 1.0f;
    private float xBoundLeft = 10.0f;
    private float xBoundRight = 90;

    [SerializeField] float jumpSpeed;
    [SerializeField] float ySpeed;
    private CharacterController characterController;
    private float originalStepOffset;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.stepOffset = originalStepOffset;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBoundary();

        if (!gameOver)
        {
        PlayerControls();
        }
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

    void PlayerBoundary()
    {
        if (transform.position.x < xBoundLeft)
        {
            transform.position = new Vector3(xBoundLeft, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xBoundRight)
        {
            transform.position = new Vector3(xBoundRight, transform.position.y, transform.position.z);
        }
        if (transform.position.z < zBoundDown)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundDown);
        }
        if (transform.position.z > zBoundUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundUp);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            gameManager.gameOverText.text = $"Game Over!";
            gameManager.gameOverText.gameObject.SetActive(true);
        }
    }


}
