using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player1"))
        {
            collision.gameObject.GetComponent<Player>().score++;
            FindObjectOfType<GameManager>().player1ScoreText.text = "Player 1: " + collision.gameObject.GetComponent<Player>().score;
        }
        else if((collision.gameObject.CompareTag("Player2")))
        {
            collision.gameObject.GetComponent<Player>().score++;
            FindObjectOfType<GameManager>().player2ScoreText.text = "Player 2: " + collision.gameObject.GetComponent<Player>().score;
        }
    }
}
