using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreDisplay : MonoBehaviour
{
   /* public Text[] highscoreText;
    Highscore highscoreManager;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    public void OnHighscoresDownloaded(Highscore.Highscores[] highscoreList) {

        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". ";
            if (highscoreList.Length > i)
            {
                highscoreText[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }

    }
    IEnumerator RefreshHighscores() {

        while (true) {
            Debug.Log(highscoreManager);
            highscoreManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        
        }
    
    
    }
    void Start()
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". Fetching...";
        }
        highscoreManager = GetComponent<Highscore>();
        StartCoroutine("RefreshHighscores");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
