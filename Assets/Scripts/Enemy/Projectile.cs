using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((playerPos - transform.position).normalized * speed * Time.deltaTime);
        if(transform.position.y < -5){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
