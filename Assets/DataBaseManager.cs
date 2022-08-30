using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
	public static DataBaseManager Instance { get; private set; }

	const string privateCode = "GAIajdCK4EyDiKx48Q156QRV8DGRNlJUSJzszBxPO71Q";
	const string publicCode = "601a512a8f40bb2a704fc2b5";
	const string webURL = "http://dreamlo.com/lb/";
	DisplayHighscores highscoreDisplay;
	public Highscore[] highscoresList;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else { Destroy(gameObject); }
	}

	public static void AddNewHighscore(string username, int score)
	{
		Instance.StartCoroutine(Instance.UploadNewHighscore(username, score));
	}

	public void DownloadHighscores()
	{
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase()
	{
		highscoreDisplay = GameObject.Find("Highscore").GetComponent<DisplayHighscores>();
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			FormatHighscores(www.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);
		}
		else
		{
			print("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i < entries.Length; i++)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username, score);
			print(highscoresList[i].username + ": " + highscoresList[i].score);
		}
	}
	IEnumerator UploadNewHighscore(string username, int score)
	{

		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error))

			print("Upload Successful");

		else
		{

			print("Error uploading: " + www.error);

		}
	}
}


public struct Highscore
{
	public string username;
	public int score;

	public Highscore(string _username, int _score)
	{
		username = _username;
		score = _score;
	}

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
