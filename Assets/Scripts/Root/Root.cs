using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player1"))
        {
            collision.gameObject.GetComponent<Player>().isCollected = true;
            collision.gameObject.GetComponent<Player>().rootCollectedByPlayer.SetActive(true);
            this.gameObject.SetActive(false);
            FindObjectOfType<SfxAudioManager>().PlayLootSound();
        }
        else if((collision.gameObject.CompareTag("Player2")))
        {
            collision.gameObject.GetComponent<Player>().isCollected = true;
            collision.gameObject.GetComponent<Player>().rootCollectedByPlayer.SetActive(true);
            this.gameObject.SetActive(false);
            FindObjectOfType<SfxAudioManager>().PlayLootSound();
        }
    }
}
