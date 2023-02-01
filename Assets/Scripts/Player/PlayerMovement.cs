using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Player player;


    //public void OnGetMovementInputEvent(InputAction.CallbackContext ctx)
    //{

    //    if (ctx.performed)
    //    {
    //        playerRb.velocity += speed * ctx.ReadValue<Vector2>();
    //        //Vector2 aim = ctx.ReadValue<Vector2>();

    //    }
    //}

    private void FixedUpdate()
    {
        if (this.gameObject.CompareTag("Player1"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerRb.velocity = player.speed * Vector2.up;
                player.playerAnim.SetBool("isWalking", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                playerRb.velocity = player.speed * Vector2.down;
                player.playerAnim.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                playerRb.velocity = player.speed * Vector2.left;
                player.playerAnim.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 270);
                playerRb.velocity = player.speed * Vector2.right;
                player.playerAnim.SetBool("isWalking", true);
            }
            else
            {
                playerRb.velocity = new Vector2(0, 0);
                player.playerAnim.SetBool("isWalking", false);
            }
        }

        if (this.gameObject.CompareTag("Player2"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerRb.velocity = player.speed * Vector2.up;
                player.playerAnim.SetBool("isWalking", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                playerRb.velocity = player.speed * Vector2.down;
                player.playerAnim.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                playerRb.velocity = player.speed * Vector2.left;
                player.playerAnim.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 270);
                playerRb.velocity = player.speed * Vector2.right;
                player.playerAnim.SetBool("isWalking", true);
            }
            else
            {
                playerRb.velocity = new Vector2(0, 0);
                player.playerAnim.SetBool("isWalking", false);
            }
        }
    }
}
