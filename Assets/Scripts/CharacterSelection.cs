using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;
    [SerializeField] TextMeshProUGUI jumpText;
    [SerializeField] TextMeshProUGUI dashText;


    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);

    }

    private void Update()
    {
        if (selectedCharacter == 0)
        {
            dashText.text = $"Spacebar: Dash";
            dashText.gameObject.SetActive(true);
            jumpText.gameObject.SetActive(false);

        }
        else
        {
            jumpText.text = $"Spacebar: Jump";
            jumpText.gameObject.SetActive(true);
            dashText.gameObject.SetActive(false);

        }
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(1);
    }

   
}
