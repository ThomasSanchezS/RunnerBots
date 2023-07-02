using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public AudioClip shieldSound;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerManager>().GetShield();
            AudioSource.PlayClipAtPoint(shieldSound, transform.position);
            Destroy(gameObject);
        }
    }
}
