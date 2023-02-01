using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int score;
    public float speed;
    public bool isCollected;
    public Animator playerAnim;
    [SerializeField] int playerindex;
    public GameObject rootCollectedByPlayer;

    private void Start()
    {
        if(this.gameObject.CompareTag("Player1"))
        {
            playerindex = 1;
        }
        else if(this.gameObject.CompareTag("Player2"))
        {
            playerindex = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerindex == 1 && isCollected && collision.gameObject.CompareTag("PlayerBase1"))
        {
            score++;
            FindObjectOfType<GameManager>().player1ScoreText.text = "Player 1: " + score;
            rootCollectedByPlayer.SetActive(false);
            isCollected = false;
        }

        if (playerindex == 2 && isCollected && collision.gameObject.CompareTag("PlayerBase2"))
        {
            score++;
            FindObjectOfType<GameManager>().player2ScoreText.text = "Player 2: " + score;
            rootCollectedByPlayer.SetActive(false);
            isCollected = false;
        }

    }
}
