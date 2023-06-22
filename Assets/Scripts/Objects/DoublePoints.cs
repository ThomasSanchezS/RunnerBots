using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePoints : MonoBehaviour
{
    public bool isDouble = false;
    public GameObject levelController;
    private LevelDistance levelDistanceScript;

    void Start() {

       levelDistanceScript = levelController.GetComponent<LevelDistance>();
    }

    void OnTriggerEnter(Collider other){

        levelDistanceScript.StartCoroutine(DuplicatePoints());
   }

   IEnumerator DuplicatePoints(){

        levelDistanceScript.disRunMultiplier = 10;
        yield return new WaitForSecondsRealtime(5f);
        levelDistanceScript.disRunMultiplier = 1;
        
   }
}
