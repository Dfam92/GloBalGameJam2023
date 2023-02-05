using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


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
    [SerializeField] SpotsManager spotsManager;
    public AudioSource playerAudio;
    [SerializeField] AudioClip footSteps;
    [SerializeField] AudioClip playerSqueak;
    public Color playerColor;

    private float defaultSpeed;
    private float speedWithLower;
    [SerializeField] float speedVariation;
    public List<GameObject> rootHold;

    [SerializeField] GameObject playerBase1;
    [SerializeField] GameObject playerBase2;

    public Vector3 defaultScale;

    [SerializeField] Sprite tauntSprite;
    [SerializeField] SpriteRenderer playerRenderer;

    private void Start()
    {
        defaultSpeed = speed;
        speedWithLower = speed * speedVariation;
        defaultScale = gameObject.transform.localScale;

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
        else if(isTauting)
        {
            speed = 0;
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

    public void PlaySqueakClip()
    {
        playerAudio.Stop();
        PlaySfx(playerSqueak, 1);
    }

    private void DisableRootHoldToBase()
    {
        foreach (GameObject root in rootHold)
        {
            if(root.activeInHierarchy)
            {
                if(this.gameObject.CompareTag("Player1"))
                {
                    Tween rootJump = root.transform.DOJump(playerBase1.transform.position, 0.5f, 1, 1);
                    rootJump.OnComplete(() => ResetTween(root));
                }
                else if(this.gameObject.CompareTag("Player2"))
                {
                    Tween rootJump = root.transform.DOJump(playerBase2.transform.position, 0.5f, 1, 1);
                    rootJump.OnComplete(() => ResetTween(root));
                }
            }
                
        }
    }

    private void DisableRootToPlayer(Player otherPlayer)
    {
        foreach (GameObject root in rootHold)
        {
            if(root.activeInHierarchy)
            {
                if (this.gameObject.CompareTag("Player1"))
                {
                    Tween rootJump = root.transform.DOJump(otherPlayer.transform.position, 0.5f, 1, 0.2f);
                    rootJump.OnComplete(() => ResetTween(root));
                }
                else if (this.gameObject.CompareTag("Player2"))
                {
                    Tween rootJump = root.transform.DOJump(otherPlayer.transform.position, 0.5f, 1, 0.2f);
                    rootJump.OnComplete(() => ResetTween(root));
                }
            }
        }
    }

    private void ResetTween(GameObject root)
    {
        root.transform.localPosition = new Vector3(0,0,0);
        root.SetActive(false);
    }

    private void GetRootForAnotherPlayer(Player player)
    {
        foreach (var root in player.rootHold)
        {
            if(root.activeInHierarchy)
            {
                rootHold[root.GetComponent<Root>().rootId].SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isCollected)
        { 
            if (collision.gameObject.CompareTag("Player2"))
            {
                Player otherPlayer = collision.gameObject.GetComponent<Player>();
                if(otherPlayer.isCollected)
                {
                    GetRootForAnotherPlayer(otherPlayer);
                    otherPlayer.GetComponent<Collider2D>().enabled = false;
                    otherPlayer.isCollected = false;
                    otherPlayer.isTauting = true;
                    otherPlayer.DisableRootToPlayer(this);
                    StartCoroutine(FinishTauntPlayer(otherPlayer));
                    otherPlayer.playerAnim.enabled = false;
                    otherPlayer.playerRenderer.sprite = tauntSprite;
                    otherPlayer.PlaySqueakClip();

                }
                
            }

            if (collision.gameObject.CompareTag("Player1"))
            {
                Player otherPlayer = collision.gameObject.GetComponent<Player>();
                if (otherPlayer.isCollected)
                {
                    GetRootForAnotherPlayer(otherPlayer);
                    otherPlayer.GetComponent<Collider2D>().enabled = false;
                    otherPlayer.isCollected = false;
                    otherPlayer.isTauting = true;
                    otherPlayer.DisableRootToPlayer(this);
                    StartCoroutine(FinishTauntPlayer(otherPlayer));
                    otherPlayer.playerAnim.enabled = false;
                    otherPlayer.playerRenderer.sprite = tauntSprite;
                    otherPlayer.PlaySqueakClip();
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerindex == 1 && isCollected && collision.gameObject.CompareTag("PlayerBase1"))
        {
            score++;
            FindObjectOfType<GameManager>().player1ScoreText.text = "P1 - " + score;
            FindObjectOfType<SfxAudioManager>().PlayPlayerGoal();
            DisableRootHoldToBase();
            isCollected = false;
            spotsManager.SpawnRandomizeRoot();
        }

        if (playerindex == 2 && isCollected && collision.gameObject.CompareTag("PlayerBase2"))
        {
            score++;
            FindObjectOfType<GameManager>().player2ScoreText.text = "P2 - " + score;
            FindObjectOfType<SfxAudioManager>().PlayPlayerGoal();
            DisableRootHoldToBase();
            isCollected = false;
            spotsManager.SpawnRandomizeRoot();
        }

        


    }

    IEnumerator FinishTauntPlayer(Player player)
    {
        yield return new WaitForEndOfFrame();
        isCollected = true;
        yield return new WaitForSeconds(2);
        player.speed = defaultSpeed;
        player.isTauting = false;
        player.GetComponent<Collider2D>().enabled = true;
        player.playerAnim.enabled = true;
    }


}
