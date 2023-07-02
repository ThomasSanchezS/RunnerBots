using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTickets : MonoBehaviour
{
    public AudioClip doubleTicketsSound;
    // Start is called before the first frame updat

    void OnTriggerEnter(Collider other){
        
        AudioSource.PlayClipAtPoint(doubleTicketsSound, transform.position);
        Destroy(gameObject);
        StartCoroutine(DuplicateTickets());
    }

   IEnumerator DuplicateTickets(){

        CollectiblesControl.ticketsMultiplier = 10;
        yield return new WaitForSecondsRealtime(10f);
        CollectiblesControl.ticketsMultiplier = 1;
        
   }
}
