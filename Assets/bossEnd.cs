using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossEnd : MonoBehaviour
{
    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    public GameObject bomb;
    public GameObject Transform;
    public Transform loc;
    public Transform lane;
    System.Random rnd = new System.Random();

    void Start()
    {
        GM.Instance.bossBeaten += onBossEnd;
        loc = GameObject.Find("bombLoc").transform;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name.ToLower())
        {
            case "level 2":
                GM.Instance.nextLevelReset();
                break;

            case "level 3":
                GM.Instance.nextLevelReset();
                break;

            case "level 1":
                GM.Instance.nextLevelReset();
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void dropBomb() {
        Instantiate(bomb, new Vector3(loc.position.x, loc.position.y, loc.position.z), bomb.transform.rotation);
    }

    public IEnumerator startDropping() {
        InvokeRepeating("dropBomb", 0, 5f);
        InvokeRepeating("pickLane", 0, 3f);
        yield return new WaitForSeconds(2.5f);
    }
    public void pickLane()
    {
        int rand = rnd.Next(1, 4);
        Debug.Log("rand " + rand);
        switch (rand)
        {
            case 1:
                if (transform.parent.GetComponent<awake>()._positionOffset.x <= 3)
                {
                    transform.parent.GetComponent<awake>()._positionOffset.x += 1f;
                }
                
                break;
            case 2:
                if (transform.parent.GetComponent<awake>()._positionOffset.x >= 3)
                {
                    transform.parent.GetComponent<awake>()._positionOffset.x -= 1f;
                }
                break;
            case 3:
                break;
            
        }
    }


    public void onBossEnd()
    {
        System.Random rnd = new System.Random();
        int temp = rnd.Next(1, 4);
        
        GM.index++;
        Debug.Log(GM.index + " is index");
        if (GM.index <= 3)
        {
            Debug.Log("spawning index");
            //GM.Instance.zPos = 47.65f;
            SceneManager.LoadScene(GM.index);
            
            
            
            
           // GM.Instance.bossActive = false;
            //GM.Instance.nextLevelReset();
            
        }
        else
        {
            Debug.Log("spawning not index");
            //GM.Instance.zPos = 47.65f;
            SceneManager.LoadScene(temp);
           
           // GM.Instance.bossActive = false;
            //GM.Instance.nextLevelReset();
            

        }

    }
}
