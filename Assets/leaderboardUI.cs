using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class leaderboardUI : MonoBehaviour
{
    public GameObject lbMenuButton;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        canvas = GameObject.Find("Canvas");
        for (int i = 0; i < 5; i++)
        {

           // DisplayHighscores.Instance.highscoreFields[i] = canvas.transform.GetChild(i+1).gameObject.GetComponent<Text>();
        }
        
        lbMenuButton.GetComponent<Button>().onClick.AddListener(() => { MainMenu(); });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
