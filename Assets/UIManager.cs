using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager Instance { get; private set; }

    public GameObject playButton;
    public GameObject scoreButton;
    public GameObject instructionsButton;
    public GameObject quitButton;
    public Text MHeadder;


    public GameObject canvasMenu;
    public GameObject canvasPause;
    public GameObject canvasGameOver;
    public Text score;

    public  GameObject pauseImage;
    public GameObject menuButton;
    public GameObject resumeButton;

    


    public GameObject header;
    public GameObject goMenuButton;
    public GameObject goImage;
    public Text coinTxt;
    public Text obsTxt;


    private void Awake()
    {

        

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            



        }
        else { Destroy(gameObject); 
               

            }

            
        

    }
    void Start()
    {
       /* canvasMenu = Instantiate(canvasMenu);
        playButton = canvasMenu.transform.GetChild(3).gameObject;

        scoreButton = canvasMenu.transform.GetChild(2).gameObject;
        instructionsButton = canvasMenu.transform.GetChild(1).gameObject;
        quitButton = canvasMenu.transform.GetChild(0).gameObject;
        MHeadder = canvasMenu.transform.GetChild(4).transform.GetComponent<Text>();

        playButton.GetComponent<Button>().onClick.AddListener(() => { Play(); });

        scoreButton.GetComponent<Button>().onClick.AddListener(() => { });

        instructionsButton.GetComponent<Button>().onClick.AddListener(() => { });

        quitButton.GetComponent<Button>().onClick.AddListener(() => { Quit(); });
        DontDestroyOnLoad(canvasMenu);
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            setGameOverInactive();
            setPauseInactive();
           // canvasPause.SetActive(false);
            
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

   

    public void setPauseInactive() {
        pauseImage.SetActive(false);
        menuButton.SetActive(false);
        resumeButton.SetActive(false);
        score.gameObject.SetActive(false);

    }
    public void setPauseActive()
    {

        pauseImage.SetActive(true);
        menuButton.SetActive(true);
        resumeButton.SetActive(true);
        score.gameObject.SetActive(true);
    }

    public void setMenuInactive()
    {
        playButton.SetActive(false);
        scoreButton.SetActive(false);
        instructionsButton.SetActive(false);
        quitButton.SetActive(false);
        MHeadder.gameObject.SetActive(false);


    }
    public void setMenuActive()
    {
        playButton.SetActive(true);
        scoreButton.SetActive(true);
        instructionsButton.SetActive(true);
        quitButton.SetActive(true);
        MHeadder.gameObject.SetActive(true);

    }

    public void setGameOverActive()
    {
        header.SetActive(true);
        goMenuButton.SetActive(true);
        goImage.SetActive(true);
        coinTxt.gameObject.SetActive(true);
        obsTxt.gameObject.SetActive(true);

    }
    public void setGameOverInactive()
    {
        header.SetActive(false);
        goMenuButton.SetActive(false);
        goImage.SetActive(false);
        coinTxt.gameObject.SetActive(false);
        obsTxt.gameObject.SetActive(false);

    }


    public void gameOver() {

        SceneManager.LoadScene("LevelComp");
        setGameOverActive();
        coinTxt.text = "Coins Collected: " + GM.Instance.coinTotal;
        obsTxt.text = "Obstacles Passed: " + GM.Instance.obstacleCount;
    }

    
    

    

    


}

