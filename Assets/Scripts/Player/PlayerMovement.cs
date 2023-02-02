using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Player player;
    [SerializeField] float timeToSit;
    private bool isSat = false;


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

    private void FixedUpdate()
    {
        if (this.gameObject.CompareTag("Player1"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerRb.velocity = player.speed * Vector2.up;
                player.playerAnim.SetBool("isWalking", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                StopSitting();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                playerRb.velocity = player.speed * Vector2.down;
                player.playerAnim.SetBool("isWalking", true);
                StopSitting();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                playerRb.velocity = player.speed * Vector2.left;
                player.playerAnim.SetBool("isWalking", true);
                StopSitting();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 270);
                playerRb.velocity = player.speed * Vector2.right;
                player.playerAnim.SetBool("isWalking", true);
                StopSitting();
            }
            else
            {
                playerRb.velocity = new Vector2(0, 0);
                player.playerAnim.SetBool("isWalking", false);
                StartCoroutine(SittingStart());
            }
        }

        if (this.gameObject.CompareTag("Player2"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerRb.velocity = player.speed * Vector2.up;
                player.playerAnim.SetBool("isWalking", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                StopSitting();
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                playerRb.velocity = player.speed * Vector2.down;
                player.playerAnim.SetBool("isWalking", true);
                StopSitting();
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                playerRb.velocity = player.speed * Vector2.left;
                player.playerAnim.SetBool("isWalking", true);
                StopSitting();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 270);
                playerRb.velocity = player.speed * Vector2.right;
                player.playerAnim.SetBool("isWalking", true);
                StopSitting();
            }
            else
            {
                playerRb.velocity = new Vector2(0, 0);
                player.playerAnim.SetBool("isWalking", false);
                StartCoroutine(SittingStart());
            }
        }
    }
}
