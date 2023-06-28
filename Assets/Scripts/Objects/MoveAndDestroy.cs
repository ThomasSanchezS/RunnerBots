using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    public GameObject levelController;
    private GenerateLevel generateLevel;
    private EndRunSequence endSequenceScript; 
    
    
    public float speed = 10f;
    private bool noRepeating = true;

    void Start()
    {
        generateLevel = levelController.GetComponent<GenerateLevel>();
        endSequenceScript = levelController.GetComponent<EndRunSequence>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {   
            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);

            if(transform.position.z < -8 && transform.position.z > -8.2 && noRepeating)
            {
            StartCoroutine(CreateSection());
            }
            if (transform.position.z < -30f)
            {
            Destroy(gameObject);
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
