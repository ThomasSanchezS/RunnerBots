using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float leftRightSpeed = 4f;
    public float acceleration;


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        
        if(Input.GetKey(KeyCode.A))
        {
            if(this.gameObject.transform.position.x > LevelBoundary.leftSide){
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }

        if(Input.GetKey(KeyCode.D))
        {
            if(this.gameObject.transform.position.x < LevelBoundary.rightSide){
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
        }
    }
}
