using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayHighscores : MonoBehaviour
{
	//public static DisplayHighscores Instance { get; private set; }
	public Text[] highscoreFields;
	//Highscores highscoresManager;
	

	void Start()
	{
		for (int i = 0; i < highscoreFields.Length; i++)
		{
			highscoreFields[i] = GameObject.Find("Score 0" + i).GetComponent<Text>();
		}
	}
    private void Awake()
    {
		

		for (int i = 0; i < highscoreFields.Length; i++)
		{
			highscoreFields[i].text = i + 1 + ". Fetching...";
		}
		StartCoroutine("RefreshHighscores");
	}

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
	{
			for (int i = 0; i < highscoreFields.Length; i++)
			{
				Debug.Log(highscoreFields);
				highscoreFields[i].text = i + 1 + ". ";
				if (i < highscoreList.Length)
				{
					highscoreFields[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
				}
			}
	}

	IEnumerator RefreshHighscores()
	{
		
			DataBaseManager.Instance.DownloadHighscores();
			yield return new WaitForSeconds(30);
		
	}
}