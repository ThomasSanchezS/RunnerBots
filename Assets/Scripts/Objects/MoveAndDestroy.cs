using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    public GameObject levelController;
    private GenerateLevel generateLevel;
    public float speed = 10f;
    private bool noRepeating = true;

    void Start()
    {
    
        generateLevel = levelController.GetComponent<GenerateLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);

        if(transform.position.z < 0 && transform.position.z > -0.2 && noRepeating)
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
        yield return new WaitForSeconds(1f);
        generateLevel.GenerateSection();
        Debug.Log("Started Creating Section");
        noRepeating = true;
    
    }
}
