using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    
    public float speed = 10f;
    private bool noRepeating = true;


    // Update is called once per frame
    void FixedUpdate()
    {   
        if(!GameManager.Instance.gameOver){
            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);

            if(transform.position.z < -10 && transform.position.z > -10.2 && noRepeating)
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
        GenerateLevel.instance.GenerateSection();
        yield return new WaitForSeconds(2f);
        Debug.Log("Started Creating Section");
        noRepeating = true;
    
    }
}
