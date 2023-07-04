using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
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
    private AudioSource shootAudio;
    private Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        animator = GameObject.Find("CameraMoveAnimator").GetComponent<Animator>();
        shootAudio = GetComponent<AudioSource>();
        positions.Add(posLeftDown);
        positions.Add(posLeftUp);
        positions.Add(posRightDown);
        positions.Add(posRightUp);
        enemyAnimator = GetComponent<Animator>();

        projectilesLength = projectiles.Count;
        startPos = transform.position;
        InvokeRepeating("RandomMultiplier", 2f, 3f);
        InvokeRepeating("InvokingProjectiles", 3f, 2f);
        InvokeRepeating("PosChanger", 6f, 4f);
        InvokeRepeating("LifeDecrease", 3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -15 || transform.position.y > 20)
        {
            transform.position = startPos;
        }
        transform.Translate(Vector3.forward * random * Time.deltaTime, Space.World);

        if (life < 1)
        {
            GameManager.Instance.bossOnScene = false;
            animator.SetBool("downRight", false);
            animator.SetBool("upLeft", false);
            animator.SetBool("downLeft", false);
            animator.SetBool("upRight", false);
            animator.SetBool("normal", true);
            Destroy(gameObject);
        }
    }
    private void LifeDecrease()
    {
        life--;
    }
    private void RandomMultiplier()
    {
        random = Random.Range(-9, 10);
    }

    private void InvokingProjectiles()
    {
        randomProjectile = Random.Range(0, projectilesLength);
        shootAudio.Play();
        enemyAnimator.SetTrigger("Shoot");
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
        transform.LookAt(player.transform);
    }
}
