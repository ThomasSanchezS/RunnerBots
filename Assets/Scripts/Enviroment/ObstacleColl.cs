using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColl : MonoBehaviour
{
    private GameObject player;
    private GameObject levelControl;

private void Start() {
    //referencia al animator del player
    player = GameObject.FindGameObjectWithTag("Player");    
    levelControl = GameObject.FindGameObjectWithTag("GameController");

}

void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player"){
            Debug.Log("te estrellaste gran jijueputa");
            player.GetComponent<PlayerMove>().enabled = false;
            levelControl.GetComponent<LevelDistance>().enabled = false;
            levelControl.GetComponent<EndRunSequence>().enabled = true;
            //true a un boolean de animacion
        }
    }
}
