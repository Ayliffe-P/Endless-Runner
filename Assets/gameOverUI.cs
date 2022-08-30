using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class gameOverUI : MonoBehaviour
{
    public GameObject header;
    public GameObject goMenuButton;
    public GameObject goImage;
    public Text coinTxt;
    public Text obsTxt;
    public GameObject saveButton;
    public InputField inputField;
    
    private void Awake()
    {
        goMenuButton.GetComponent<Button>().onClick.AddListener(() => { MainMenu(); });
        saveButton.GetComponent<Button>().onClick.AddListener(() => { saveScore(); });
        coinTxt.text = "Coins Collected: " + GM.Instance.coinTotal;
        obsTxt.text = "Obstacles Passed: " + GM.Instance.obstacleCount;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void gameOver()
    {

        

    }
    public void MainMenu()
    {
       
        SceneManager.LoadScene("MainMenu");
        

    }
    public void saveScore()
    {
        string text = inputField.text;
        Debug.Log(text);
        if (Regex.IsMatch(text, @"^[a-zA-Z]+$") == true)
        {
            DataBaseManager.AddNewHighscore(inputField.text, GM.Instance.score);
            
        }

    }
}
