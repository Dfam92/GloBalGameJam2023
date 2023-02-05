using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public int rootId;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player1"))
        {
            Player player1 = collision.gameObject.GetComponent<Player>();
            player1.isCollected = true;
            int rootIndex = player1.rootHold.FindIndex(root => root.GetComponent<Root>().rootId == this.rootId);
            player1.rootHold[rootIndex].SetActive(true);
            this.gameObject.SetActive(false);
            FindObjectOfType<SfxAudioManager>().PlayLootSound();
        }
        else if((collision.gameObject.CompareTag("Player2")))
        {
            Player player2 = collision.gameObject.GetComponent<Player>();
            player2.isCollected = true;
            int rootIndex = player2.rootHold.FindIndex(root => root.GetComponent<Root>().rootId == this.rootId);
            player2.rootHold[rootIndex].SetActive(true);
            this.gameObject.SetActive(false);
            FindObjectOfType<SfxAudioManager>().PlayLootSound();
        }
    }
}
