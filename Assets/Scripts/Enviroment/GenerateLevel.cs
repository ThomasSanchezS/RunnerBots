using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public static GenerateLevel instance;
    public GameObject[] bossSection;
    public GameObject[] section;
    public float zPos = 35f;
    private bool creatingSection = false;
    public int secNum;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GenerateSection()
    {
        secNum = Random.Range(0, 3);
        if (GameManager.Instance.bossOnScene == false)
        {
            Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        }
        else{
            Instantiate(bossSection[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        
        }
        creatingSection = false;

    }
}
