using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private GameManager gameManager;
    public int numberOfItems { get; private set; }

     void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void ItemsCollected()
    {
        numberOfItems++;
        gameManager.UpdateScore(numberOfItems);
    }
}
