using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleColl : MonoBehaviour
{
    private GameObject player;
    private GameObject levelControl;
    private PlayerManager playerManager; 
    private GameObject section;
    private MoveAndDestroy moveAndDestroyScript;

    private void Start()
    {
        //referencia al animator del player
        player = GameObject.FindGameObjectWithTag("Player");
        levelControl = GameObject.FindGameObjectWithTag("GameController");
        playerManager = player.GetComponent<PlayerManager>();
        section = GameObject.FindGameObjectWithTag("Section");
        moveAndDestroyScript = section.GetComponent<MoveAndDestroy>();
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (playerManager.shielded == true)
            {
                Destroy(gameObject);
                playerManager.shielded = false;
            }
            else
            {
                Debug.Log("te estrellaste gran jijueputa");
                levelControl.GetComponent<LevelDistance>().enabled = false;
                levelControl.GetComponent<EndRunSequence>().enabled = true;
                player.GetComponent<PlayerMove>().enabled = false;
                moveAndDestroyScript.crashed = true;
                Debug.Log(moveAndDestroyScript.crashed);
                //true a un boolean de animacion
            }
        }
    }
}