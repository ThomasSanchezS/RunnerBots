using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTickets : MonoBehaviour
{
  
  void OnTriggerEnter(Collider other)
  {
    CollectiblesControl.ticketsCount += 1 * CollectiblesControl.ticketsMultiplier;
    this.gameObject.SetActive(false);
  }
}
