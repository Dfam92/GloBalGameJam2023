using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
                collision.GetComponent<Player>().gameObject.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f).OnComplete(() => 
                collision.GetComponent<Player>().gameObject.transform.DOScale(collision.GetComponent<Player>().defaultScale,0.2f));

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
                StartCoroutine(EnterHoleDelayed(collision,index));
                StartCoroutine(ReactiveCollider(collision.GetComponent<Player>()));
                collision.GetComponent<Player>().isDigging = true;
            }
        }
    }

    IEnumerator ReactiveCollider(Player player)
    {
        yield return new WaitForSeconds(2);
        player.isDigging = false;
    }

    IEnumerator EnterHoleDelayed(Collider2D collision, int index)
    {
        yield return new WaitForSeconds(0.2f);
        collision.GetComponent<Player>().gameObject.transform.position = holesManager.holes[index].transform.position;
    }
}
