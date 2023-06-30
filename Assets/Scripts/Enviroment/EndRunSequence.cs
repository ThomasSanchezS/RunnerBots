using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    public static EndRunSequence instance;
    public GameObject liveTickets;
    public GameObject liveDis;
    public GameObject endScreen;
    public GameObject fadeOut;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(2f);
        liveTickets.SetActive(false);
        liveDis.SetActive(false);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2F);
        SceneManager.LoadScene("Menu");
    }
}
