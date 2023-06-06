using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectiblesControl : MonoBehaviour
{
    public static int ticketsCount;
    public TMP_Text ticketsUI;

    void Update()
    {
        ticketsUI.text = "Tickets: " + ticketsCount.ToString();
    }
}
