using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI gameOverText;
    private int score;
    public GameObject[] characterPrefabs;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private CinemachineVirtualCamera cineMachine;
    private GameObject prefab;
    private PlayerInventory inventory;
    public PlayerController playerController;
    public bool gameOver = false;
    public GameObject gameOverPanel;


    // Start is called before the first frame update
    void Start()
    {
        // Load selected character
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        prefab = characterPrefabs[selectedCharacter];
        GameObject spawnObject = Instantiate(prefab, spawnPosition.position, Quaternion.identity);
        cineMachine.Follow = spawnObject.transform;

        //Get components from the player at start
        inventory = spawnObject.GetComponent<PlayerInventory>();
        playerController = spawnObject.GetComponent<PlayerController>();



       
    }

    // Update is called once per frame
    void Update()
    {

        if (inventory.numberOfItems == 10)
        {
            gameOver = true;
            gameOverText.text = $"Demo completed";
            gameOverText.gameObject.SetActive(true);
            gameOverPanel.gameObject.SetActive(true);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        itemText.text = $"Items: {scoreToAdd}";

    }
}
