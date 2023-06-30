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

    }

    private GameObject[] sections;
    private List<MoveAndDestroy> moveAndDestroyScripts = new List<MoveAndDestroy>();

    private void OnCollisionEnter(Collision other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sections = GameObject.FindGameObjectsWithTag("Section");
        foreach (GameObject section in sections)
        {
            moveAndDestroyScripts.Add(section.GetComponent<MoveAndDestroy>());
        }
        Debug.Log(sections.Length);
        levelControl = GameObject.FindGameObjectWithTag("GameController");
        playerManager = player.GetComponent<PlayerManager>();
        section = GameObject.FindGameObjectWithTag("Section");
        // moveAndDestroyScript = section.GetComponent<MoveAndDestroy>();

        if (other.gameObject.tag == "Player")
        {
            if (playerManager.shielded == true)
            {
                Destroy(gameObject);
                playerManager.shielded = false;
            }
            else
            {
                foreach (MoveAndDestroy moveAndDestroyScript in moveAndDestroyScripts)
                {
                    moveAndDestroyScript.crashed = true;
                }
                // moveAndDestroyScript.crashed = true;
                Debug.Log("te estrellaste gran jijueputa");
                PlayerMove.canMove = false;
                levelControl.GetComponent<LevelDistance>().enabled = false;
                levelControl.GetComponent<EndRunSequence>().enabled = true;
                player.GetComponent<PlayerMove>().enabled = false;

                //true a un boolean de animacion
            }
        }
    }
}