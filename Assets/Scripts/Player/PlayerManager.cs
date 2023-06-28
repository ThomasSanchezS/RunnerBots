using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool shielded = false;
    public bool crashed{get; set;}
    private Animator playerAnimator;

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
}
