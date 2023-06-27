using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void OnTriggerEnter(Collider Other){
        if (Other.gameObject.tag == "Player"){
            Other.GetComponent<State>().GetShield();
        }
    }
}
