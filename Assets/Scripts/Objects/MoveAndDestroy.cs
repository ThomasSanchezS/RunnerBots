using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    public GameObject levelController;
    private GenerateLevel generateLevel;
    private EndRunSequence endSequenceScript; 
    public bool crashed{get; set;}

    public float speed = 10f;
    private bool noRepeating = true;

    void Start()
    {
        generateLevel = levelController.GetComponent<GenerateLevel>();
        endSequenceScript = levelController.GetComponent<EndRunSequence>();
        crashed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(crashed == false){
            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);

            if(transform.position.z < -30 && transform.position.z > -30.2 && noRepeating)
            {
            StartCoroutine(CreateSection());
            }
            if (transform.position.z < -50f)
                {
                    Destroy(gameObject);
                }
        } else {
            StopAllCoroutines();
        }
    }

    IEnumerator CreateSection()
    {
        noRepeating = false;
        generateLevel.GenerateSection();
        yield return new WaitForSeconds(2f);
        Debug.Log("Started Creating Section");
        noRepeating = true;
    
    }
}
