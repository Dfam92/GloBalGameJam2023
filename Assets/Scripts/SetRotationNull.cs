using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotationNull : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y +0.7f,transform.position.z);
    }
}
