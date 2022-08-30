using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class terrainGenerator : MonoBehaviour
{
    public List<Transform> obstacleSpawns;
    public List<Transform> coinSpawns;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToLower() == "player")
        {
            if (SceneManager.GetActiveScene().name == "level 1")
            {
                GM.Instance.generateLevelOne();
            }
            else if (SceneManager.GetActiveScene().name == "level 2")
            {
                GM.Instance.generateLevelTwo();
            }
            else if (SceneManager.GetActiveScene().name == "level 3")
            {
                GM.Instance.generateLevelThree();
            }

            //GM.Instance.gen();
            Debug.Log("Generating");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
