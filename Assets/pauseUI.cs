using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseImage;
    public GameObject menuButton;
    public GameObject resumeButton;
    public Text score;

    private void Awake()
    {
        pauseImage.SetActive(false);
        menuButton.SetActive(false);
        resumeButton.SetActive(false);
        
        menuButton.GetComponent<Button>().onClick.AddListener(() => { MainMenu(); });
        resumeButton.GetComponent<Button>().onClick.AddListener(() => { Resume(); });
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        score.text = GM.Instance.scoreText;
    }
    public void Pause()
    {
        Time.timeScale = 0.0001f;
        pauseImage.SetActive(true);
        menuButton.SetActive(true);
        resumeButton.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
        
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseImage.SetActive(false);
        menuButton.SetActive(false);
        resumeButton.SetActive(false);
    }
}
