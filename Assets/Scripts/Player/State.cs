using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public bool shielded = false;
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
