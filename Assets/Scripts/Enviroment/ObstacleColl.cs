using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleColl : MonoBehaviour
{
    private GameObject player;
    private GameObject levelControl;
    private GenerateLevel generateLevel;
    

private void Start() {
    //referencia al animator del player
    player = GameObject.FindGameObjectWithTag("Player");    
    levelControl = GameObject.FindGameObjectWithTag("GameController");
    generateLevel = levelControl.GetComponent<GenerateLevel>();
}

void OnCollisionEnter(Collision other) 
    {
        
        if (other.gameObject.tag == "Player"){
            State state = player.GetComponent<State>();
            if(state.shielded == true)
            {
                Destroy(gameObject);
                state.shielded = false;
            }
            else if(state.shielded == false){
            Debug.Log("te estrellaste gran jijueputa");
            generateLevel.keepMoving = false;
            levelControl.GetComponent<LevelDistance>().enabled = false;
            levelControl.GetComponent<EndRunSequence>().enabled = true;
            //true a un boolean de animacion
            }
            
        }
    }
}
