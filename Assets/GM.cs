using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GM : MonoBehaviour
{
    public static GM Instance { get; private set; }

    public static int index = 1;

    public event Action bossLoad;
    public event Action bossBeaten;
    public event Action obsPassed;
    public event Action onPowerUp1;
    public event Action onPowerUp2;
    public event Action onPowerUp3;

    public GameObject icon1;
    public GameObject icon2;

    public static float vertVel = 0;

    public static float timeTotal = 0;
    public float waittoload = 0;

    public static float zVelAdj = 1;

    public static string lvlCompStatus = "";

    public Transform bbNoPit;
    public Transform bbPitMid;

    public Transform coinObj;
    public Transform obstObj;
    public Transform capsuleObj;

    public Transform powerUp1;
    public Transform powerUp2;
    public Transform powerUp3;
    public Transform SpikeWall;
    public Transform pad;
    public Transform spikePillar;

    public Transform lvlOnePref_One;
    public Transform lvlOnePref_Two;
    public Transform lvlOnePref_Three;

    public Transform lvlTwoPref_One;
    public Transform lvlTwoPref_Two;
    public Transform lvlTwoPref_Three;

    public Transform lvlThreePref_One;
    public Transform lvlThreePref_Two;
    public Transform lvlThreePref_Three;

    public int padCount = 0;

    public GameObject bossPrefab;
    public GameObject boss;
    public GameObject player;
    public GameObject thisPlayer;

    public Transform coin;

    public Transform largePref;
    public Transform largePrefHole;
    public Transform largePrefHole2nd;


    public Transform stanPref;
    public Transform stanPrefSpawner;
    public Transform stanPrefHole;
    public Transform stanPrefHole2;
    public Transform bossSpawn;
    public Transform stanPrefLeft;
    public Transform stanPrefRight;

    public AudioSource music;

    public int randNum;

    public float zPos = 61.2f;

    public int zScenePos = 0;
    // Start is called before the first frame update


    public string scoreText ;
    public int score = 0;
    public int obstacleCount = 0;
    public int coinTotal = 0;


    public Scene currentScene;


    public bool bossActive = false;
    public bool bossSpawned = false;



    System.Random rnd = new System.Random();

    public void nextLevelReset()
    {
        if (!music.isPlaying)
        {
            music.Play();
        }
       
        bossActive = false;
        bossSpawned = false;
        bossLoad = null;
        bossBeaten = null;
        Debug.Log(player);
        player.SetActive(true);
        player.transform.position = new Vector3(0, 0.5f, 0);
        boss = Instantiate( bossPrefab, new Vector3(0, 0.5f, 0), bossPrefab.transform.rotation);
        padCount = 0;
        Debug.Log("HWASH");
        //player.transform.GetChild(9).gameObject.SetActive(false);
        zPos = 61.2f;
        icon1 = GameObject.Find("CanvasIcon").transform.GetChild(0).gameObject;
        icon2 = GameObject.Find("CanvasIcon").transform.GetChild(1).gameObject;
        Debug.Log(bossLoad);

}
    private void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        music = GetComponent<AudioSource>();
        music.Play();
        player = Instantiate(thisPlayer, new Vector3(0, 0.5f, 0), thisPlayer.transform.rotation);
        //boss = Instantiate(bossPrefab, new Vector3(0, 0.5f, 0), boss.transform.rotation);
        icon1 = GameObject.Find("CanvasIcon").transform.GetChild(0).gameObject;
        icon2 = GameObject.Find("CanvasIcon").transform.GetChild(1).gameObject;


        }
        else { Destroy(gameObject); 
        
        }
        for (int i = 0; i < 9; i++)
        {
            Instantiate(stanPref, new Vector3(0, -1.2f, zPos), stanPref.rotation);
            Debug.Log("Spawned");
            zPos += 6.8f;
        }
        
        Debug.Log(zPos);
        
        currentScene = SceneManager.GetActiveScene();
        
        
    }

    void Start()
    {
        
        Debug.Log(currentScene);
       


    }
    

    public void powerUp1Trigger()
    {
        if (onPowerUp1 != null)
        {
            //  Debug.Log("invoking 1");
            onPowerUp1();
        }
    }
    public void powerUp2Trigger()
    {
        if (onPowerUp2 != null)
        {
            //  Debug.Log("invoking 2");
            onPowerUp2();
        }


    }
    public void powerUp3Trigger()
    {
        if (onPowerUp3 != null)
        {
            //  Debug.Log("invoking 3");
            onPowerUp3();
        }


    }
    public void onBossLoad()
    {
        if (bossLoad != null)
        {
            //  Debug.Log("invoking");
            bossLoad();
            
           
        }
    }
    public void onBossEnd()
    {
        if (bossBeaten != null)
        {
            //  Debug.Log("invoking");
            bossBeaten();
        }
    }
    public void onObsPassed()
    {
        if (obsPassed != null)
        {
            Debug.Log("activating");
            obsPassed();
        }
    }
    public void powerUp1Activate()
    {
        // Debug.Log("triggered");
        StartCoroutine(GM.Instance.timer1(2));
    }
    public void PowerupActivate()
    {

        Time.timeScale = 1.5f;

    }
    public void PowerupDeactivate()
    {
        Time.timeScale = 1;

    }

    public IEnumerator timer1(int time)
    {
        GM.Instance.onPowerUp1 += PowerupActivate;
        GM.Instance.powerUp1Trigger();
        yield return new WaitForSeconds(time);
        Debug.Log("timing power up 1");
        Deactivate1();



    }
    public void Deactivate1()
    {

        GM.Instance.onPowerUp1 -= PowerupActivate;
        GM.Instance.onPowerUp1 += PowerupDeactivate;
        GM.Instance.powerUp1Trigger();
    }

    public void powerUp2Activate()
    {

        // Debug.Log("triggered");
        StartCoroutine(GM.Instance.timer2(10));





    }
    public void Powerup2Activate()
    {
        player.gameObject.GetComponent<moveorb>().invulnerable = true;
        icon1.SetActive(true);

    }
    public void Powerup2Deactivate()
    {
        player.gameObject.GetComponent<moveorb>().invulnerable = false;
        icon1.SetActive(false);
    }
    public IEnumerator timer2(int time)
    {
        GM.Instance.onPowerUp2 += Powerup2Activate;
        GM.Instance.powerUp2Trigger();
        yield return new WaitForSeconds(time);
        Debug.Log("timing power up 1");
        Deactivate2();



    }

    public void Deactivate2()
    {

        GM.Instance.onPowerUp2 -= Powerup2Activate;
        GM.Instance.onPowerUp2 += Powerup2Deactivate;
        GM.Instance.powerUp2Trigger();
    }
    public void powerUp3Activate()
    {
        // Debug.Log("triggered");
        icon2.SetActive(true);
        StartCoroutine(GM.Instance.timer3(10));
    }
    public IEnumerator timer3(int time)
    {
        GM.Instance.onPowerUp3 += Powerup3Activate;
        GM.Instance.powerUp3Trigger();
        yield return new WaitForSeconds(time);
        Debug.Log("Stopping Bombs");
        Deactivate3();
    }
    public void Powerup3Activate()
    {
        boss.gameObject.transform.GetChild(0).GetComponent<bossEnd>().CancelInvoke("dropBomb");
    }
    public void Powerup3Deactivate()
    {
        boss.gameObject.transform.GetChild(0).GetComponent<bossEnd>().InvokeRepeating("dropBomb", 0, 5);

    }
    public void Deactivate3()
    {
        icon2.SetActive(false);
        GM.Instance.onPowerUp2 -= Powerup3Activate;
        GM.Instance.onPowerUp2 += Powerup3Deactivate;
        GM.Instance.powerUp2Trigger();
    }

    public void coinSpawn(int numOfCoins,List<Transform> coinSpawns) {

        for (int i = 0; i < numOfCoins; i++)
        {
            int num = rnd.Next(0, coinSpawns.Count);
            Instantiate(coin, new Vector3(coinSpawns[num].position.x,coinSpawns[num].position.y + 1.31f, (coinSpawns[num].position.z)), coin.transform.rotation);
            coinSpawns.RemoveAt(num);
        }

    }
    public void powerUpSpawn(List<Transform> coinSpawns) {

        if (SceneManager.GetActiveScene().name == "level 1")
        {
        int num = rnd.Next(0, coinSpawns.Count);
        Instantiate(powerUp1, new Vector3(coinSpawns[num].position.x, coinSpawns[num].position.y + 1.31f, (coinSpawns[num].position.z)), powerUp1.transform.rotation);
        coinSpawns.RemoveAt(num);
        }
        else if (SceneManager.GetActiveScene().name == "level 2")
        {
            int num;
            int temp = rnd.Next(0, 2);
            switch (temp)
            {
                
                case 0:
                     num = rnd.Next(0, coinSpawns.Count);
                    Instantiate(powerUp1, new Vector3(coinSpawns[num].position.x, coinSpawns[num].position.y + 1.31f, (coinSpawns[num].position.z)), powerUp1.transform.rotation);
                    coinSpawns.RemoveAt(num);
                    break;
                case 1:
                     num = rnd.Next(0, coinSpawns.Count);
                    Instantiate(powerUp2, new Vector3(coinSpawns[num].position.x, coinSpawns[num].position.y + 1.31f, (coinSpawns[num].position.z)), powerUp2.transform.rotation);
                    coinSpawns.RemoveAt(num);
                    break;
              
            }
        }
        else if (SceneManager.GetActiveScene().name == "level 3")
        {
            int num;
            int temp = rnd.Next(0, 3);
            switch (temp)
            {

                case 0:
                    num = rnd.Next(0, coinSpawns.Count);
                    Instantiate(powerUp1, new Vector3(coinSpawns[num].position.x, coinSpawns[num].position.y + 1.31f, (coinSpawns[num].position.z)), powerUp1.transform.rotation);
                    coinSpawns.RemoveAt(num);
                    break;
                case 1:
                    num = rnd.Next(0, coinSpawns.Count);
                    Instantiate(powerUp2, new Vector3(coinSpawns[num].position.x, coinSpawns[num].position.y + 1.31f, (coinSpawns[num].position.z)), powerUp2.transform.rotation);
                    coinSpawns.RemoveAt(num);
                    break;
                case 2:
                    num = rnd.Next(0, coinSpawns.Count);
                    Instantiate(powerUp3, new Vector3(coinSpawns[num].position.x, coinSpawns[num].position.y + 1.31f, (coinSpawns[num].position.z)), powerUp3.transform.rotation);
                    coinSpawns.RemoveAt(num);
                    break;

            }
        }


    }
    public void padSpawn(List<Transform> coinSpawns) {
        int num = rnd.Next(0, coinSpawns.Count);
        Instantiate(pad, new Vector3(coinSpawns[num].position.x, coinSpawns[num].position.y, (coinSpawns[num].position.z)), pad.transform.rotation);
        coinSpawns.RemoveAt(num);
    }
    public void ObstacleSpawnLevelThree(List<Transform> obstSpawns)
    {
        for (int i = 0; i < 2; i++)
        {
            int num = rnd.Next(0, obstSpawns.Count);
            GameObject temp = Instantiate(SpikeWall, new Vector3(obstSpawns[num].position.x, obstSpawns[num].position.y, (obstSpawns[num].position.z)), SpikeWall.transform.rotation).gameObject;
            obstSpawns.RemoveAt(num);

            if (bossActive == false)
            {
                temp.transform.GetChild(0).GetComponent<spikeAnimator>().setIdle();
            }
            else
            {
                temp.transform.GetChild(0).GetComponent<spikeAnimator>().setMoving();
            }
        }
    }
    public void generateLevelThree()
    {
        GameObject temp = null;
        int coinId = 0;



        if (Time.timeSinceLevelLoad >= 15 && bossActive == false)
        {

            Debug.Log("Spawner Set");
            temp = Instantiate(bossSpawn, new Vector3(0, -1.2f, zPos), bossSpawn.rotation).gameObject;
            bossActive = true;


            zPos += 6.8f;
        }
        else if (bossActive == false)
        {
            int prefabNum = rnd.Next(0, 4);
            switch (prefabNum)
            {
                case 0:
                    temp = Instantiate(lvlThreePref_One, new Vector3(0, -1.2f, zPos), lvlTwoPref_One.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 1:
                    temp = Instantiate(lvlThreePref_Two, new Vector3(0, -1.2f, zPos), lvlTwoPref_Two.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 2:
                    temp = Instantiate(lvlThreePref_Three, new Vector3(0, -1.2f, zPos), lvlTwoPref_Three.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 3:
                    temp = Instantiate(stanPrefSpawner, new Vector3(0, -1.2f, zPos), stanPrefSpawner.rotation).gameObject;
                    zPos += 6.8f;
                    break;

            }
        }
        else if (bossActive == true)
        {
            int prefabNum = rnd.Next(0, 3);
            switch (prefabNum)
            {
                case 0:
                    temp = Instantiate(largePref, new Vector3(0, -1.2f, zPos), largePref.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 1:
                    temp = Instantiate(largePrefHole, new Vector3(0, -1.2f, zPos), largePrefHole.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 2:
                    temp = Instantiate(largePrefHole2nd, new Vector3(0, -1.2f, zPos), largePrefHole2nd.rotation).gameObject;
                    zPos += 20.4f;
                    break;

            }
        }
        int numOfCoins = 0;

        if (temp.GetComponent<terrainGenerator>().coinSpawns.Count > 1)
        {
            numOfCoins = rnd.Next(1, temp.GetComponent<terrainGenerator>().coinSpawns.Count / 2);
            int obj;
            if (bossActive)
            {
                obj = 3;
            }
            else
            {
                { obj = 2; }
            }

            int item = rnd.Next(0, obj);

            switch (item)
            {
                case 0:
                    coinSpawn(numOfCoins, temp.GetComponent<terrainGenerator>().coinSpawns);
                    break;
                case 1:
                    powerUpSpawn(temp.GetComponent<terrainGenerator>().coinSpawns);
                    break;
                case 2:
                    padSpawn(temp.GetComponent<terrainGenerator>().coinSpawns);
                    break;

            }
        }
        if (temp.GetComponent<terrainGenerator>().obstacleSpawns.Count > 1)
        {
            ObstacleSpawnLevelThree(temp.GetComponent<terrainGenerator>().obstacleSpawns);
        }


    }

    public void ObstacleSpawnLevelTwo(List<Transform> obstSpawns)
    {
        for (int i = 0; i < 2; i++)
        {
            int num = rnd.Next(0, obstSpawns.Count);
            Instantiate(spikePillar, new Vector3(obstSpawns[num].position.x, obstSpawns[num].position.y, (obstSpawns[num].position.z)), spikePillar.transform.rotation);
            obstSpawns.RemoveAt(num);
        }
    }

    public void generateLevelTwo() {
        GameObject temp = null;
        int coinId = 0;



        if (Time.timeSinceLevelLoad >= 15 && bossActive == false)
        {

            Debug.Log("Spawner Set");
            temp = Instantiate(bossSpawn, new Vector3(0, -1.2f, zPos), bossSpawn.rotation).gameObject;
            bossActive = true;


            zPos += 6.8f;
        }
        else if (bossActive == false)
        {
            int prefabNum = rnd.Next(0, 4);
            switch (prefabNum)
            {
                case 0:
                    temp = Instantiate(lvlTwoPref_One, new Vector3(0, -1.2f, zPos), lvlTwoPref_One.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 1:
                    temp = Instantiate(lvlTwoPref_Two, new Vector3(0, -1.2f, zPos), lvlTwoPref_Two.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 2:
                    temp = Instantiate(lvlTwoPref_Three, new Vector3(0, -1.2f, zPos), lvlTwoPref_Three.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 3:
                    temp = Instantiate(stanPrefSpawner, new Vector3(0, -1.2f, zPos), stanPrefSpawner.rotation).gameObject;
                    zPos += 6.8f;
                    break;

            }
        }
        else if (bossActive == true)
        {
            int prefabNum = rnd.Next(0, 3);
            switch (prefabNum)
            {
                case 0:
                    temp = Instantiate(largePref, new Vector3(0, -1.2f, zPos), largePref.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 1:
                    temp = Instantiate(largePrefHole, new Vector3(0, -1.2f, zPos), largePrefHole.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 2:
                    temp = Instantiate(largePrefHole2nd, new Vector3(0, -1.2f, zPos), largePrefHole2nd.rotation).gameObject;
                    zPos += 20.4f;
                    break;

            }
        }
        int numOfCoins = 0;

        if (temp.GetComponent<terrainGenerator>().coinSpawns.Count > 1)
        {
            numOfCoins = rnd.Next(1, temp.GetComponent<terrainGenerator>().coinSpawns.Count / 2);
            int obj;
            if (bossActive)
            {
                obj = 3;
            }
            else
            {
                { obj = 2; }
            }

            int item = rnd.Next(0, obj);

            switch (item)
            {
                case 0:
                    coinSpawn(numOfCoins, temp.GetComponent<terrainGenerator>().coinSpawns);
                    break;
                case 1:
                    powerUpSpawn(temp.GetComponent<terrainGenerator>().coinSpawns);
                    break;
                case 2:
                    padSpawn(temp.GetComponent<terrainGenerator>().coinSpawns);
                    break;

            }
        }
        if (temp.GetComponent<terrainGenerator>().obstacleSpawns.Count > 1)
        {
            ObstacleSpawnLevelTwo(temp.GetComponent<terrainGenerator>().obstacleSpawns);
        }
        

    }

    public void generateLevelOne()
    {
        
        GameObject temp = null;
        int coinId = 0;
        
        
       
        if (Time.timeSinceLevelLoad >= 15 && bossActive == false)
        {

            Debug.Log("Spawner Set");
            temp = Instantiate(bossSpawn, new Vector3(0, -1.2f, zPos), bossSpawn.rotation).gameObject;
            bossActive = true;


            zPos += 6.8f;
        }
        else if (bossActive == false)
        {
            int prefabNum = rnd.Next(0, 4);
            switch (prefabNum)
            {
                case 0:
                    temp = Instantiate(lvlOnePref_One, new Vector3(0, -1.2f, zPos), lvlOnePref_One.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 1:
                    temp = Instantiate(lvlOnePref_Two, new Vector3(0, -1.2f, zPos), lvlOnePref_Two.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 2:
                    temp = Instantiate(lvlOnePref_Three, new Vector3(0, -1.2f, zPos), lvlOnePref_Three.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 3:
                    temp = Instantiate(stanPrefSpawner, new Vector3(0, -1.2f, zPos), stanPrefSpawner.rotation).gameObject;
                    zPos += 6.8f;
                    break;
                    
            }
        }
        else if (bossActive == true)
        {
            int prefabNum = rnd.Next(0, 3);
            switch (prefabNum)
            {
                case 0:
                    temp = Instantiate(largePref, new Vector3(0, -1.2f, zPos), largePref.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 1:
                    temp = Instantiate(largePrefHole, new Vector3(0, -1.2f, zPos), largePrefHole.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                case 2:
                    temp = Instantiate(largePrefHole2nd, new Vector3(0, -1.2f, zPos), largePrefHole2nd.rotation).gameObject;
                    zPos += 20.4f;
                    break;
                
            }
        }
        int numOfCoins = 0;
        
        if (temp.GetComponent<terrainGenerator>().coinSpawns.Count > 1)
        {
             numOfCoins = rnd.Next(1, temp.GetComponent<terrainGenerator>().coinSpawns.Count / 2);
            int obj;
            if (bossActive)
            {
                obj = 3;
            }
            else
            {
                { obj = 2; }
            }

            int item = rnd.Next(0, obj);

            switch (item)
            {
                case 0:
                    coinSpawn(numOfCoins, temp.GetComponent<terrainGenerator>().coinSpawns);
                    break;
                case 1:
                    powerUpSpawn(temp.GetComponent<terrainGenerator>().coinSpawns);
                    break;
                case 2:
                    padSpawn(temp.GetComponent<terrainGenerator>().coinSpawns);
                    break;

            }
        }
            
            
           // coinSpawn(numOfCoins, temp.GetComponent<terrainGenerator>().coinSpawns);
            
            



            //coinSpawn(numOfCoins, temp.GetComponent<terrainGenerator>().coinSpawns);
        
        //boosterSpawn(numOfCoins, temp.GetComponent<terrainGenerator>().coinSpawns);


        /*if (Time.timeSinceLevelLoad >= 15 && bossActive == false)
        {
            min = 9;
            max = 14;
            Debug.Log("Spawner Set");
            temp = Instantiate(bossSpawn, new Vector3(0, -1.2f, zPos), bossSpawn.rotation).gameObject;
            bossActive = true;

            id = spawnPos(min, max);
            coinId = spawnPos(min, max);
            zPos += 6.8f;
        }
        */
    }

    public void gen()
    {

        GameObject temp = null;
        int id = 0;
        int coinId = 0;
        int min = 0;
        int max = 0;
        

        if (Time.timeSinceLevelLoad >= 15 && bossActive == false)
        {
            min = 9;
            max = 14;
            Debug.Log("Spawner Set");
            temp = Instantiate(bossSpawn, new Vector3(0, -1.2f, zPos), bossSpawn.rotation).gameObject;
            bossActive = true;

            id = spawnPos(min, max);
            coinId = spawnPos(min, max);
            zPos += 6.8f;
        }
        else if (SceneManager.GetActiveScene().name == "level 1")
        {
            if (bossSpawned == false)
            {
            min = 9;
            max = 14;
            temp = Instantiate(stanPrefSpawner, new Vector3(0, -1.2f, zPos), stanPrefSpawner.rotation).gameObject;
            id = spawnPos(min, max);
            coinId = spawnPos(min, max);
                zPos += 6.8f;
            }
            else if (bossSpawned == true)
            {
                min = 13;
                max = 22;
                temp = Instantiate(largePref, new Vector3(0, -1.2f, zPos), largePref.rotation).gameObject;
                id = spawnPos(min, max);
                coinId = spawnPos(min, max);
                zPos += 6.8f;
            }
            


        }

        else if (SceneManager.GetActiveScene().name == "level 2")
        {
            if (bossSpawned == false)
            {
            int ter = rnd.Next(0, 3);
            if (ter == 0)
            {
                min = 9;
                max = 14;
                temp = Instantiate(stanPrefSpawner, new Vector3(0, -1.2f, zPos), stanPrefSpawner.rotation).gameObject;
                id = spawnPos(min, max);
                coinId = spawnPos(min, max);
                    zPos += 6.8f;
                }
            else if (ter == 1)
            {
                Debug.Log("Hole");
                min = 8;
                max = 10;
                temp = Instantiate(stanPrefHole, new Vector3(0, -1.2f, zPos), stanPrefSpawner.rotation).gameObject;
                id = spawnPos(min, max);
                coinId = spawnPos(min, max);
                    zPos += 6.8f;
                }
            else if (ter == 2)
            {
                Debug.Log("Hole2");
                temp = Instantiate(stanPrefHole2, new Vector3(0, -1.2f, zPos), stanPrefSpawner.rotation).gameObject;
                id = 0;
                    zPos += 6.8f;
                }
            }
            else if (bossSpawned == true)
            {
                min = 13;
                max = 22;
                temp = Instantiate(largePref, new Vector3(0, -1.2f, zPos), largePref.rotation).gameObject;
                id = spawnPos(min, max);
                coinId = spawnPos(min, max);
                zPos += 6.8f;
            }
            
            



        }
        else if (SceneManager.GetActiveScene().name == "level 3")
        {
            if (bossSpawned == false)
            {
                int ter = rnd.Next(0, 3);
                if (ter == 0)
                {
                    min = 9;
                    max = 11;
                    temp = Instantiate(stanPrefSpawner, new Vector3(0, -1.2f, zPos), stanPrefSpawner.rotation).gameObject;
                    id = spawnPos(min, max);
                    coinId = spawnPos(min, max);
                    zPos += 6.8f;
                }
                else if (ter == 1)
                {
                    Debug.Log("Left");
                    min = 8;
                    max = 12;
                    temp = Instantiate(stanPrefLeft, new Vector3(0, -1.2f, zPos), stanPrefSpawner.rotation).gameObject;
                    id = spawnPos(min, max);
                    coinId = spawnPos(min, max);
                    zPos += 6.8f;
                }
                else if (ter == 2)
                {
                    min = 8;
                    max = 12;
                    Debug.Log("Right");
                    temp = Instantiate(stanPrefRight, new Vector3(0, -1.2f, zPos), stanPrefSpawner.rotation).gameObject;
                    id = spawnPos(min, max);
                    coinId = spawnPos(min, max);
                    zPos += 6.8f;
                }
            }
            else if (bossSpawned == true)
            {
                int ter = rnd.Next(0, 3);
                if (ter == 0)
                {
                min = 13;
                max = 22;
                temp = Instantiate(largePref, new Vector3(0, -1.2f, zPos), largePref.rotation).gameObject;
                id = spawnPos(min, max);
                coinId = spawnPos(min, max);
                zPos += 6.8f;
                }
                if (ter == 1)
                {
                    min = 18;
                    max = 20;
                    temp = Instantiate(largePrefHole, new Vector3(0, -1.2f, zPos), largePrefHole.rotation).gameObject;
                    id = spawnPos(min, max);
                    coinId = spawnPos(min, max);
                    zPos += 10.2f;
                }
                if (ter == 2)
                {
                    min = 18;
                    max = 20;
                    temp = Instantiate(largePrefHole2nd, new Vector3(0, -1.2f, zPos), largePrefHole2nd.rotation).gameObject;
                    id = spawnPos(min, max);
                    coinId = spawnPos(min, max);
                    zPos += 10.2f;
                }

            }


        }

        if (id != 0)
        {
            Debug.Log(temp + " " + id);
            if (contains(temp, id) == false)
            {
                spawnObs(temp, randObs(), id);
               
            }

            if (contains(temp, coinId) == false)
            {
                spawnCoins(temp, coinId);
            }
            else
            {

                spawnCoins(temp, spawnPos(coinId, min, max));

            }
        }


        









    }
    public void scoreReset() {

        score = 0;
        obstacleCount = 0;
        coinTotal = 0;
    
    }
    public bool contains(GameObject pref, int pos)
    {
          Debug.Log(pos);
        if (pref.transform.GetChild(pos).transform.childCount == 0)
        {
            return false;
        }
        else { return true; }


    }

    public int spawnPos(int min, int max)
    {

        int pos = rnd.Next(min, max);

        return pos;


    }
    public int spawnPos(int except, int min, int max)
    {
        int pos = rnd.Next(min, max); ;
        while (pos == except)
        {
            pos = rnd.Next(min, max);
        }

        return pos;


    }

    public Transform randObs()
    {

        int random = rnd.Next(0, 100);
        Transform temp = null;


        if (SceneManager.GetActiveScene().name == "level 1" && bossActive == true)
        {
            if (random >= 0 && random <= 10)
            {
                temp = powerUp1;
            }
            if (random > 10 && random <= 90)
            {
                temp = SpikeWall;
            }
            if (random > 90 && random <= 100)
            {
                temp = pad;
            }
        }
        if (SceneManager.GetActiveScene().name == "level 1" && bossActive == false)
        {
            if (random >= 0 && random <= 15)
            {
                temp = powerUp1;
            }
            if (random > 15 && random <= 100)
            {
                temp = SpikeWall;
            }


        }
        if (SceneManager.GetActiveScene().name == "test3" && bossActive == false)
        {
            if (random >= 0 && random <= 15)
            {
                temp = powerUp1;
            }
            if (random > 15 && random <= 100)
            {
                temp = SpikeWall;
            }


        }

        if (SceneManager.GetActiveScene().name == "level 2" && bossActive == true)
        {
            if (random >= 0 && random <= 5)
            {
                temp = powerUp1;
            }

            if (random > 5 && random <= 10)
            {
                temp = powerUp2;
            }
            if (random > 10 && random <= 90)
            {
                temp = spikePillar;
            }
            if (random > 90 && random <= 100)
            {
                temp = pad;
            }
        }
        if (SceneManager.GetActiveScene().name == "level 2" && bossActive == false)
        {
            if (random >= 0 && random <= 5)
            {
                temp = powerUp1;
            }

            if (random > 5 && random <= 15)
            {
                temp = powerUp2;
            }
            if (random > 15 && random <= 100)
            {
                temp = spikePillar;
            }

        }

        if (SceneManager.GetActiveScene().name == "level 3" && bossActive == true)
        {
            if (random >= 0 && random <= 3)
            {
                temp = powerUp1;
            }

            if (random > 3 && random <= 7)
            {
                temp = powerUp2;
            }
            if (random > 7 && random <= 10)
            {
                temp = powerUp3;
            }
            if (random > 10 && random <= 60)
            {
                temp = spikePillar;
            }
            if (random > 60 && random <= 90)
            {
                temp = SpikeWall;
            }
            if (random > 90 && random <= 100)
            {
                temp = pad;
            }
        }
        if (SceneManager.GetActiveScene().name == "level 3" && bossActive == false)
        {
            if (random >= 0 && random <= 3)
            {
                temp = powerUp1;
            }

            if (random > 3 && random <= 7)
            {
                temp = powerUp2;
            }
            if (random > 7 && random <= 10)
            {
                temp = powerUp3;
            }
            if (random > 10 && random <= 65)
            {
                temp = spikePillar;
            }
            if (random > 65 && random <= 100)
            {
                temp = SpikeWall;
            }

        }


        return temp;

    }

    

        public void generate()
    {

        System.Random rand = new System.Random();

        int ran = rand.Next(9, 15);
        int spawner = rand.Next(1, 7);
        int spawnCoin = ran;

        while (spawnCoin == ran)
        {
            //  Debug.Log("Same");
            spawnCoin = rand.Next(9, 15);
        }
        //   Debug.Log("Changed");

        Transform obj = null;

        switch (spawner)
        {
            case 1:
                obj = powerUp1;
                break;
            case 2:
                obj = powerUp2;
                break;
            case 3:
                obj = powerUp3;
                break;
            case 4:
            case 5:
            case 6:
                obj = SpikeWall;

                // Debug.Log("Spiked wall");
                break;
        }
        GameObject temp;
        if (Time.timeSinceLevelLoad >= 15)
        {
            temp = Instantiate(bossSpawn, new Vector3(0, -1.2f, zPos), bossSpawn.rotation).gameObject;
            Debug.Log(Time.timeSinceLevelLoad);
        }
        else
        {
            temp = Instantiate(stanPrefSpawner, new Vector3(0, -1.2f, zPos), stanPrefSpawner.rotation).gameObject;
        }


        spawnObs(temp, obj, ran);
        spawnCoins(temp, spawnCoin);
        Debug.Log(temp.transform.GetChild(ran).transform.GetChild(0));

        zPos += 6.8f;


        //Debug.Log("End Gen");
    }

    public void spawnObs(GameObject Pref, Transform item, int pos)
    {
        GameObject temp;



        if (item == SpikeWall)
        {

            temp = Instantiate(item, new Vector3(Pref.transform.GetChild(pos).position.x, Pref.transform.GetChild(pos).position.y, Pref.transform.GetChild(pos).position.z + 0), item.transform.rotation).gameObject;
            temp.transform.Rotate(0, 0, 0);
            temp.transform.parent = Pref.transform.GetChild(pos);
            if (SceneManager.GetActiveScene().name == "level 1")
            {
                temp.transform.GetChild(0).GetComponent<spikeAnimator>().setIdle();
            }
            else if (bossSpawned == true && SceneManager.GetActiveScene().name == "level 3")
            {
                temp.transform.GetChild(0).GetComponent<spikeAnimator>().setMoving();
            }
            else { temp.transform.GetChild(0).GetComponent<spikeAnimator>().setIdle(); }

            

        }
        else
    if (item == spikePillar)
        {

            temp = Instantiate(item, new Vector3(Pref.transform.GetChild(pos).position.x, Pref.transform.GetChild(pos).position.y, Pref.transform.GetChild(pos).position.z + 0), item.transform.rotation).gameObject;

            temp.transform.parent = Pref.transform.GetChild(pos);



        }
        else
        if (item == pad)
        {
            temp = Instantiate(item, new Vector3(Pref.transform.GetChild(pos).position.x, Pref.transform.GetChild(pos).position.y, Pref.transform.GetChild(pos).position.z), item.transform.rotation).gameObject;
            temp.transform.parent = Pref.transform.GetChild(pos);
        }
        else
        {
            Debug.Log(item);
            
            temp = Instantiate(item, new Vector3(Pref.transform.GetChild(pos).position.x, Pref.transform.GetChild(pos).position.y + 1.31f, Pref.transform.GetChild(pos).position.z), item.transform.rotation).gameObject;
            
            temp.transform.parent = Pref.transform.GetChild(pos);
        }



    }


    


    public void spawnCoins(GameObject pref, int spawn)
    {

        GameObject temp;

        temp = Instantiate(coin, new Vector3(pref.transform.GetChild(spawn).position.x, pref.transform.GetChild(spawn).position.y + 1.31f, pref.transform.GetChild(spawn).position.z), coin.transform.rotation).gameObject;
        temp.transform.parent = pref.transform.GetChild(spawn);

    }




    // Update is called once per frame
    void Update()
    {


        if (SceneManager.GetActiveScene().name == "level 1" || SceneManager.GetActiveScene().name == "level 2" || SceneManager.GetActiveScene().name == "level 3")
        {
             
            scoreText = "Score: " + score; 
        }

        timeTotal += Time.deltaTime;

        
    }
}

    
