using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 2;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
        Vector3 lookDirection = (gameManager.playerController.gameObject.transform.position - transform.position).normalized;
       transform.Translate(lookDirection * speed * Time.deltaTime);
    }

    
}
