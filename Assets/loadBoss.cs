using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadBoss : MonoBehaviour
{
    public GameObject boss;
    
    public Material skybox1;

    private void Awake()
    {
        
        

    }
    void Start()
    {
       
        GM.Instance.bossLoad += onBossLoad;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onBossLoad()
    {

        // Instantiate(boss, new Vector3(GM.Instance.player.transform.position.x, GM.Instance.player.transform.position.y + 5.8f, GM.Instance.player.transform.position.z + 71.2f), boss.transform.rotation, GM.Instance.player.transform);
        GM.Instance.bossSpawned = true;
        RenderSettings.skybox = skybox1;
        GM.Instance.boss.SetActive(true);
        Debug.Log(GM.Instance.boss.transform.GetChild(0).GetComponent<bossEnd>().startDropping());
        StartCoroutine(GM.Instance.boss.transform.GetChild(0).GetComponent<bossEnd>().startDropping());


    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToLower() == "player")
        {
            GM.Instance.onBossLoad();
            
        }
        
    }
}
