using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColl : MonoBehaviour
{
    public GameObject player;

private void Start() {

    player = GameObject.FindGameObjectWithTag("Player");    

}

void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player"){
            Debug.Log("te estrellaste gran jijueputa");
            player.GetComponent<PlayerMove>().enabled = false;
        }
    }
}
