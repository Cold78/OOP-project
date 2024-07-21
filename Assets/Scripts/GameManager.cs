using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI gameOverText;
    private int score;
    private PlayerInventory playerInventory;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();


    }

    // Update is called once per frame
    void Update()
    {
        if (playerInventory.numberOfItems == 10)
        {
            playerController.gameOver = true;
            gameOverText.text = $"Demo completed";
            gameOverText.gameObject.SetActive(true);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        itemText.text = $"Items: {scoreToAdd}";

    }
}
