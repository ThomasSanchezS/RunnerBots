using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject camAnimator;
    private Animator animator;
    public GameObject enemy;
    private int enemyCount;
    private int randomPos;
    private Vector3 pos;
    private Vector3 posRightDown = new Vector3(10, 1, 0);
    private Vector3 posRightUp = new Vector3(10, 10, 0);
    private Vector3 posLeftDown = new Vector3(-10, 1, 0);
    private Vector3 posLeftUp = new Vector3(-10, 10, 0);
    private List<Vector3> positions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        animator = camAnimator.GetComponent<Animator>();

        positions.Add(posLeftDown);
        positions.Add(posLeftUp);
        positions.Add(posRightDown);
        positions.Add(posRightUp);

        InvokeRepeating("CreateEnemy", 30f, 60f);
    }
    private void CreateEnemy()
    {

        GameObject[] sectionsLoaded = GameObject.FindGameObjectsWithTag("Section");
        foreach (GameObject section in sectionsLoaded)
        {
            Destroy(section);
        
        }
        GameManager.Instance.bossOnScene = true;
        GenerateLevel.instance.GenerateSection();
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        Debug.Log(enemyCount);

        if (enemyCount < 1)
        {
            randomPos = Random.Range(0, 4);
            pos = positions[randomPos];
            GameObject enemyInstance = Instantiate(enemy, pos, Quaternion.identity);
            enemyInstance.transform.LookAt(player.transform);
            switch (pos)
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
        }

    }
}
