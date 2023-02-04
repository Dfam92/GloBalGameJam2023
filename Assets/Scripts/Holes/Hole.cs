using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] HolesManager holesManager;
    [SerializeField] int holeIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.CompareTag("Hole"))
        {
            if(!collision.GetComponent<Player>().isDigging)
            {
                Debug.Log(holesManager.holes.Count);
                int index = Random.Range(0, holesManager.holes.Count);
                bool differentNumber = false;
                while(!differentNumber)
                {
                    index = Random.Range(0, holesManager.holes.Count);
                    if (index != holeIndex)
                    {
                        differentNumber = true;
                    }
                    
                }
                collision.GetComponent<Player>().gameObject.transform.position = holesManager.holes[index].transform.position;
                StartCoroutine(ReactiveCollider(collision.GetComponent<Player>()));
                collision.GetComponent<Player>().isDigging = true;
            }
        }
    }

    IEnumerator ReactiveCollider(Player player)
    {
        yield return new WaitForSeconds(1);
        player.isDigging = false;
    }
}
