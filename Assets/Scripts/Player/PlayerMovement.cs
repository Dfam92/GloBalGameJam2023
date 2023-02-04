using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Player player;
    [SerializeField] float timeToSit;
    [SerializeField] float torque;
    private bool isSat = false;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    //public void OnGetMovementInputEvent(InputAction.CallbackContext ctx)
    //{

    //    if (ctx.performed)
    //    {
    //        playerRb.velocity += speed * ctx.ReadValue<Vector2>();
    //        //Vector2 aim = ctx.ReadValue<Vector2>();

    //    }
    //}

    private IEnumerator SittingStart()
    {
        if(!isSat)
        {
            yield return new WaitForSeconds(timeToSit);
            player.playerAnim.SetBool("isSitting", true);
            isSat = true;
        }
    }

    private void StopSitting()
    {
        StopAllCoroutines();
        player.playerAnim.SetBool("isSitting", false);
        isSat = false;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (player.isAttacking)
    //    {
            
    //    }
    //}

    //private void Attack()
    //{

    //    if (!player.isAttacking)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            player.playerAnim.SetBool("isAttacking", true);
    //            player.isAttacking = true;
    //        }
    //    }

    //    if (player.isAttacking)
    //    {
    //        StartCoroutine(CanAttackAgain());
    //    }
    //}

    //IEnumerator CanAttackAgain()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    player.playerAnim.SetBool("isAttacking", false);
    //    player.isAttacking = false;
    //}

    private void FixedUpdate()
    {
        //Attack();
        if(gameManager.gameStarted)
        {
            if (this.gameObject.CompareTag("Player1"))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    playerRb.velocity = player.speed * Vector2.up;
                    player.playerAnim.SetBool("isWalking", true);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    StopSitting();
                    player.PlayPlayerSteps();
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    playerRb.velocity = player.speed * Vector2.down;
                    player.playerAnim.SetBool("isWalking", true);
                    StopSitting();
                    player.PlayPlayerSteps();
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    playerRb.velocity = player.speed * Vector2.left;
                    player.playerAnim.SetBool("isWalking", true);
                    StopSitting();
                    player.PlayPlayerSteps();
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 270);
                    playerRb.velocity = player.speed * Vector2.right;
                    player.playerAnim.SetBool("isWalking", true);
                    StopSitting();
                    player.PlayPlayerSteps();
                }
                else
                {
                    playerRb.velocity = new Vector2(0, 0);
                    player.playerAnim.SetBool("isWalking", false);
                    StartCoroutine(SittingStart());
                    player.playerAudio.Stop();
                }
            }

            if (this.gameObject.CompareTag("Player2"))
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    playerRb.velocity = player.speed * Vector2.up;
                    player.playerAnim.SetBool("isWalking", true);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    player.PlayPlayerSteps();
                    StopSitting();
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    playerRb.velocity = player.speed * Vector2.down;
                    player.playerAnim.SetBool("isWalking", true);
                    player.PlayPlayerSteps();
                    StopSitting();
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    playerRb.velocity = player.speed * Vector2.left;
                    player.playerAnim.SetBool("isWalking", true);
                    player.PlayPlayerSteps();
                    StopSitting();
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 270);
                    playerRb.velocity = player.speed * Vector2.right;
                    player.playerAnim.SetBool("isWalking", true);
                    player.PlayPlayerSteps();
                    StopSitting();
                }
                else
                {
                    playerRb.velocity = new Vector2(0, 0);
                    player.playerAnim.SetBool("isWalking", false);
                    StartCoroutine(SittingStart());
                    player.playerAudio.Stop();
                }
            }
        }
        
    }
}
