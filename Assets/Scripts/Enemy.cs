using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 2;
    private GameManager gameManager;
    private Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
        EnemyMovement(); 
        }
        else
        {
            gameObject.SetActive(false);
        }

    }

    void EnemyMovement()
    {
        transform.LookAt(gameManager.playerController.transform, Vector3.up);
        //transform.Translate(transform.forward * speed * Time.deltaTime);
       // transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
       var pos = transform.forward * speed * Time.deltaTime;
        transform.position += new Vector3(pos.x, 0, pos.z);
       // Debug.LogError(transform.forward);
       // Debug.LogError(Vector3.forward);


        // float enemyDirectionX = (gameManager.playerController.gameObject.transform.position.x - transform.position.x);
        // float enemyDirectionZ = (gameManager.playerController.gameObject.transform.position.z - transform.position.z);
        // Vector3 lookDirection = new Vector3(enemyDirectionX, 0, enemyDirectionZ).normalized;
        // //Vector3 lookDirection = (gameManager.playerController.gameObject.transform.position - transform.position).normalized;
        //transform.Translate(lookDirection * speed * Time.deltaTime);
    }


}
