using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    public List<GameObject> projectiles = new List<GameObject>();
    private float life = 10.0f;
    private int random;
    private Vector3 startPos;
    private int projectilesLength;
    private int randomProjectile;
    private int randomPos;
    private Vector3 posRightDown = new Vector3(10, 1, 0);
    private Vector3 posRightUp = new Vector3(10, 10, 0);
    private Vector3 posLeftDown = new Vector3(-10, 1, 0);
    private Vector3 posLeftUp = new Vector3(-10, 10, 0);
    private List<Vector3> positions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("CameraMoveAnimator").GetComponent<Animator>();

        positions.Add(posLeftDown);
        positions.Add(posLeftUp);
        positions.Add(posRightDown);
        positions.Add(posRightUp);

        projectilesLength = projectiles.Count;
        startPos = transform.position;
        InvokeRepeating("RandomMultiplier", 5f, 3f);
        InvokeRepeating("InvokingProjectiles", 3f, 2f);
        InvokeRepeating("PosChanger", 6f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20 || transform.position.y > 20)
        {
            transform.position = startPos;
        }
        transform.Translate(Vector3.forward * random * Time.deltaTime);

        if (life < 1)
        {
            Destroy(gameObject);
        }
    }
    private void RandomMultiplier()
    {
        ;
        random = Random.Range(-2, 3);
    }

    private void InvokingProjectiles()
    {
        randomProjectile = Random.Range(0, projectilesLength);
        Instantiate(projectiles[randomProjectile], transform.position, Quaternion.identity);
    }

    private void PosChanger()
    {
        randomPos = Random.Range(0, 4);
        startPos = positions[randomPos];
        switch (startPos)
        {
            case var value when value == posLeftDown:
                animator.SetBool("downRight", false);
                animator.SetBool("upLeft", false);
                animator.SetBool("downLeft", false);
                animator.SetBool("upRight", true);
                break;
            case var value when value == posLeftUp:
                animator.SetBool("upLeft", false);
                animator.SetBool("downLeft", false);
                animator.SetBool("upRight", false);
                animator.SetBool("downRight", true);
                break;
            case var value when value == posRightDown:
                animator.SetBool("downRight", false);
                animator.SetBool("downLeft", false);
                animator.SetBool("upRight", false);
                animator.SetBool("upLeft", true);
                break;
            case var value when value == posRightUp:
                animator.SetBool("downRight", false);
                animator.SetBool("upLeft", false);
                animator.SetBool("upRight", false);
                animator.SetBool("downLeft", true);
                break;
        }
        transform.position = startPos;
    }
}
