using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private GameManager gameManager;
    public int numberOfItems { get; private set; }
    [SerializeField] AudioClip collectSound;
    private AudioSource itemAudio;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        itemAudio = GetComponent<AudioSource>();

    }

    public void ItemsCollected()
    {
        numberOfItems++;
        gameManager.UpdateScore(numberOfItems);
        itemAudio.PlayOneShot(collectSound, 0.5f);

    }
}
