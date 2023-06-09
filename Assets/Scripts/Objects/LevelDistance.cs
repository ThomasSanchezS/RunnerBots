using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public TMP_Text disPoints;
    public float disRun;
    public bool addingDis = false;
    public float disDelay = 0.3f;
    public TMP_Text endPoints;
    public float disRunMultiplier = 1;

    void Update()
    {
        if(addingDis == false && PlayerMove.canMove)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }
    
    public IEnumerator AddingDis()
    {
        disRun += 1 * disRunMultiplier;
        disPoints.text = "Puntos: " + disRun.ToString(); 
        endPoints.text = "Puntos: " + disRun.ToString(); 
        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }
}
