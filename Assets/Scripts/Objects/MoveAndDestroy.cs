using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    public GameObject levelController;
    private GenerateLevel generateLevel;
    private EndRunSequence endSequenceScript; 
    private bool keepMoving = false; 
    
    
    public float speed = 10f;
    private bool noRepeating = true;

    void Start()
    {
        generateLevel = levelController.GetComponent<GenerateLevel>();
        endSequenceScript = levelController.GetComponent<EndRunSequence>();

    }

    // Update is called once per frame
    void Update()
    {
        keepMoving = generateLevel.keepMoving;
        Debug.Log(keepMoving);
        if(keepMoving == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);

            if(transform.position.z < -5 && transform.position.z > -5.2 && noRepeating)
            {
            StartCoroutine(CreateSection());
            }
            if (transform.position.z < -30f)
            {
            Destroy(gameObject);
            }

        } else if(keepMoving == false){

            StopCoroutine(CreateSection());
        }
        
    }

    IEnumerator CreateSection()
    {
        noRepeating = false;
        yield return new WaitForSeconds(1f);
        generateLevel.GenerateSection();
        Debug.Log("Started Creating Section");
        noRepeating = true;
    
    }
}
