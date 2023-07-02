using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePoints : MonoBehaviour
{
    public bool isDouble = false;
    public GameObject levelController;
    private LevelDistance levelDistanceScript;
    public AudioClip duplicatePoints;

    void Start() {

       levelDistanceScript = levelController.GetComponent<LevelDistance>();
    }

    void OnTriggerEnter(Collider other){

        AudioSource.PlayClipAtPoint(duplicatePoints, transform.position);
        levelDistanceScript.StartCoroutine(DuplicatePoints());
        Destroy(gameObject);
   }

   IEnumerator DuplicatePoints(){

      levelDistanceScript.disRunMultiplier = 10;
      yield return new WaitForSecondsRealtime(5f);
      levelDistanceScript.disRunMultiplier = 1;
        
   }
}
