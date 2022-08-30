using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class instructionUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inMenuButton;
    private void Awake()
    {
        inMenuButton.GetComponent<Button>().onClick.AddListener(() => { MainMenu(); });
    }
    void Start()
    {
        
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
