using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool shielded = false;
    public bool crashed{get; set;}
    private Animator playerAnimator;
    private PlayerMove playerMove;

    private void Start() {
        playerAnimator = GetComponent<Animator>();
        
    }
    // Start is called before the first frame update
    public void GetShield()
    {
        shielded = true;
    }

    public void BrakeShield()
    {
        shielded = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Obstacle") && !shielded)
        {
            
            PlayerMove.canMove = false;
            playerAnimator.SetBool("isRunning", false);
            playerAnimator.SetBool("isDead", true);
            Debug.Log(PlayerMove.canMove);
        }
    }
}
