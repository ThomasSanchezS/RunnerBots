using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingRoad : MonoBehaviour
{
    private Vector3 startPos;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerMove.canMove){
        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        }
        Debug.Log("puede moverse: " + PlayerMove.canMove);
        if (transform.position.z < -12)
        {
            transform.position = startPos;
        }
    }
}
