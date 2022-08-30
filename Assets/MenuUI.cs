using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    public GameObject playButton;
    public GameObject scoreButton;
    public GameObject instructionsButton;
    public GameObject quitButton;
    public Text MHeadder;
    private void Awake()
    {
        playButton.GetComponent<Button>().onClick.AddListener(() => { Play(); });

        scoreButton.GetComponent<Button>().onClick.AddListener(() => { loadScoreScene(); });

        instructionsButton.GetComponent<Button>().onClick.AddListener(() => { instuctionScene(); });

        quitButton.GetComponent<Button>().onClick.AddListener(() => { Quit(); });
    }
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        
        SceneManager.LoadScene("level 1");
        
        if (GM.Instance != null)
        {
            Debug.Log("not null");
            GM.Instance.scoreReset();
           // GM.Instance.nextLevelReset();
            
        }
        
        Time.timeScale = 1;
      
        

        

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name.ToLower())
        {

            case "level 1":
                if (GM.Instance != null)
                {
                    Debug.Log("not null");
                    
                     GM.Instance.nextLevelReset();

                }
                break;
        }
    }


    public void Quit()
    {
        Application.Quit();

    }
    public void loadScoreScene()
    {
        SceneManager.LoadScene("HighScoreScene");

    }
    public void instuctionScene()
    {
        SceneManager.LoadScene("instructionScene");

    }
}
