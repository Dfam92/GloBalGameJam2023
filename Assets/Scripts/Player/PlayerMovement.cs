using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D playerRb;


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
                playerRb.velocity += speed * Vector2.up;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                playerRb.velocity += speed * Vector2.down;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                playerRb.velocity += speed * Vector2.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                playerRb.velocity += speed * Vector2.right;
            }
            else
            {
                playerRb.velocity = new Vector2(0, 0);
            }
        }

        if (this.gameObject.CompareTag("Player2"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerRb.velocity += speed * Vector2.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                playerRb.velocity += speed * Vector2.down;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerRb.velocity += speed * Vector2.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                playerRb.velocity += speed * Vector2.right;
            }
            else
            {
                playerRb.velocity = new Vector2(0, 0);
            }
        }
    }
}
