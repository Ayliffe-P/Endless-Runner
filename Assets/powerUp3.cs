using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp3 : MonoBehaviour
{
    void Start()
    {
        //GM.Instance.onPowerUp3 += PowerupActivate;
    }
    public void PowerupActivate()
    {
       // Debug.Log(Time.timeScale);
        Time.timeScale = 1.5f;
       // Debug.Log(Time.timeScale);
    }
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("triggered");
        if (other.tag.ToLower() == "player")
        {
            GM.Instance.powerUp3Activate();
        }
       
    }
}
