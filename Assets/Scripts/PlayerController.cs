using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    public float speed;

    [SerializeField] float rotationSpeed;

   

    [SerializeField] float jumpSpeed;
    [SerializeField] float ySpeed;
    public CharacterController characterController;
    private float originalStepOffset;

    private GameManager gameManager;
    public Vector3 movementDirection;

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

        if (!gameManager.gameOver)
        {
        PlayerControls();
        }
    }

    public void PlayerControls()
    {
        // Player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        PLayerSkills();


         movementDirection = new Vector3(horizontalInput, 0, verticalInput);
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

    public virtual void PLayerSkills()
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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.gameOver = true;
            Debug.Log("Game Over");
            gameManager.gameOverText.text = $"Game Over!";
            gameManager.gameOverText.gameObject.SetActive(true);
        }
    }


}
