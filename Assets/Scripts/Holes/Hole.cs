using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] GameObject hole1;
    [SerializeField] GameObject hole2;
    [SerializeField] GameObject hole3;
    [SerializeField] GameObject hole4;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.CompareTag("Hole1"))
        {
            collision.GetComponent<Player>().gameObject.transform.position = hole2.transform.position;
        }
        //else if (this.gameObject.CompareTag("Hole2"))
        //{
        //    collision.GetComponent<Player>().gameObject.transform.position = hole1.transform.position;
        //}

        //if (this.gameObject.CompareTag("Hole3"))
        //{
        //    collision.GetComponent<Player>().gameObject.transform.position = hole4.transform.position;
            
        //}
        if (this.gameObject.CompareTag("Hole4"))
        {
            collision.GetComponent<Player>().gameObject.transform.position = hole3.transform.position;
        }
    }
}
