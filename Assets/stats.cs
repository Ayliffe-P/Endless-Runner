using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Text coinTxt;
    public Text obsPassed;
    // Update is called once per frame
    void Update()
    {
        coinTxt.text = GM.Instance.coinTotal.ToString();
        obsPassed.text = GM.Instance.obstacleCount.ToString();
        //if (gameObject.name == "coinstxt")
        // {
        //     GetComponent<TextMesh>().text = "Coins : " + GM.Instance.coinTotal.ToString();
        // }
        if (gameObject.name == "timetxt")
        {
            GetComponent<TextMesh>().text = "Time : " + GM.timeTotal;
        }
        if (gameObject.name == "runstatus")
        {
            GetComponent<TextMesh>().text = GM.lvlCompStatus;
        }
    }
}
