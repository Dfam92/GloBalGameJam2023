using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int score;
    public float speed;

    public bool isCollected = false;
    public bool isAttacking = false;
    public bool isTauting = false;
    public bool isDigging = false;

    public Animator playerAnim;
    [SerializeField] int playerindex;
    public GameObject rootCollectedByPlayer;
    [SerializeField] SpotsManager spotsManager;
    public AudioSource playerAudio;
    [SerializeField] AudioClip footSteps;
    public Color playerColor;

    private float defaultSpeed;
    private float speedWithLower;
    [SerializeField] float speedVariation;

    private void Start()
    {
        defaultSpeed = speed;
        speedWithLower = speed * speedVariation;

        if(this.gameObject.CompareTag("Player1"))
        {
            playerindex = 1;
        }
        else if(this.gameObject.CompareTag("Player2"))
        {
            playerindex = 2;
        }
    }

    public void PlaySfx(AudioClip clip, float value)
    {
        if (playerAudio != null)
        {
            if(!playerAudio.isPlaying)
            {
                playerAudio.PlayOneShot(clip, value);
            }
            
        }

    }

    private void Update()
    {
        if(isCollected)
        {
            speed = defaultSpeed - speedWithLower;
        }
        else
        {
            speed = defaultSpeed;
        }
    }

    public void PlayPlayerSteps()
    {
        PlaySfx(footSteps, 1 - 0.6f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerindex == 1 && isCollected && collision.gameObject.CompareTag("PlayerBase1"))
        {
            score++;
            FindObjectOfType<GameManager>().player1ScoreText.text = "P1: " + score;
            FindObjectOfType<SfxAudioManager>().PlayPlayerGoal();
            rootCollectedByPlayer.SetActive(false);
            isCollected = false;
            spotsManager.SpawnRandomizeRoot();
        }

        if (playerindex == 2 && isCollected && collision.gameObject.CompareTag("PlayerBase2"))
        {
            score++;
            FindObjectOfType<GameManager>().player2ScoreText.text = "P2: " + score;
            FindObjectOfType<SfxAudioManager>().PlayPlayerGoal();
            rootCollectedByPlayer.SetActive(false);
            isCollected = false;
            spotsManager.SpawnRandomizeRoot();
        }

    }

   
}
