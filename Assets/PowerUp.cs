using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static PowerUp Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);




        }
        else { Destroy(gameObject); }
    }



        /* public GameObject player;
         public string powerupType;
         private void Awake()
         {
             Debug.Log("Awake");
             setPowerup();


             if (gameObject.tag.ToLower() == "powerup1")
             {
                 GM.Instance.onPowerUp1 += Powerup1Activate;
             }
             if (this.gameObject.tag.ToLower() == "powerup2")
             {

                 GM.Instance.onPowerUp2 += Powerup2Activate;
             }
             if (this.gameObject.tag.ToLower() == "powerup3")
             {
                 GM.Instance.onPowerUp3 += Powerup3Activate;
             }
         }

         void setPowerup() {

             if (gameObject.tag.ToLower() == "powerup1")
             {
                 powerupType = "powerup1";
                 Debug.Log("Setup 1");
             }
             if (this.gameObject.tag.ToLower() == "powerup2")
             {

                 powerupType = "powerup2";
                 Debug.Log("Setup 2");
             }
             if (this.gameObject.tag.ToLower() == "powerup3")
             {
                 powerupType = "powerup3";
                 Debug.Log("Setup 3");
             }



         }
         public void PowerupActivate()
         {

             if (gameObject.tag.ToLower() == "powerup1")
             {
                 Debug.Log("ACTIVATE 1");
                 Time.timeScale = 1.5f;
             }
             if (gameObject.tag.ToLower() == "powerup2")
             {
                 Debug.Log("ACTIVATE 2");

                 player.gameObject.GetComponent<moveorb>().invulnerable = true;
             }
             if (gameObject.tag.ToLower() == "powerup3")
             {
                 Debug.Log("ACTIVATE 3");
             }
          }

         public void Powerup1Activate() {
             Time.timeScale = 1.5f;
             Debug.Log("ACTIVATE 1");
         }
         public void Powerup2Activate() {
             player.gameObject.GetComponent<moveorb>().invulnerable = true;
             Debug.Log("ACTIVATE 2");
         }
         public void Powerup3Activate() {
             Debug.Log("ACTIVATE 3");
         }



         private void OnTriggerEnter(Collider other)
         {
             if (gameObject.tag == "powerup1")
             {
                 GM.Instance.powerUp1Trigger();
             }
             if (gameObject.tag == "powerup2")
             {
                 GM.Instance.powerUp2Trigger();
             }
             if (gameObject.tag == "powerup3")
             {
                 GM.Instance.powerUp3Trigger();
             }

         }*/


    }