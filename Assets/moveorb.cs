
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveorb : MonoBehaviour  
{
    //public KeyCode moveL;
    //public KeyCode moveR;

    //public float horizVel = 0;
    // public int laneNum = 2;
    //public string controlLocked = "n";


    public playerAudio pAudio;
    public Transform boomObj;
    public float moveSpeed;
    public float leftToRightSpeed;
    public  bool invulnerable = false;


    private void Awake()
    {
        
            DontDestroyOnLoad(gameObject);




        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GM.vertVel, 4);

        /* if ((Input.GetKeyDown(moveL)) && (laneNum>1) && (controlLocked == "n"))
         {

             horizVel = -2;
             StartCoroutine(stopSlide());
             laneNum -= 1;
             controlLocked = "y";
         }
         else if ((Input.GetKeyDown(moveR)) && (laneNum<3) && (controlLocked == "n"))
         {

             horizVel = 2;
             StartCoroutine(stopSlide());
             laneNum += 1;
             controlLocked = "y";
         }*/
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); // move forward
        float sideToSide = Input.GetAxis("Horizontal") * leftToRightSpeed * Time.deltaTime; //getting a +or- we apply it blow

        transform.Translate(sideToSide, 0, 0); //(X, Y, Z) move side to side
    }

    void OnTriggerEnter(Collider other)
    {
        if (invulnerable == false)
        {
            if (gameObject.tag.ToLower() == "player")
            {
                if (other.gameObject.tag == "lethal")
                {
                    GM.Instance.music.Stop();
                    Debug.Log(other.gameObject.name + " is what killed you");
                    //Camera.main.transform.parent = null;

                    gameObject.SetActive(false);

                    GM.zVelAdj = 0;
                    Instantiate(boomObj, transform.position, boomObj.rotation);
                    GM.lvlCompStatus = "Fail";
                    
                    SceneManager.LoadScene("LevelComp");


                    

                }
            }
            
        }
        
        if (other.gameObject.tag == "Powerup1" || other.gameObject.tag == "Powerup2" || other.gameObject.tag == "Powerup3") {

            Destroy(other.gameObject);
            pAudio.playPowerUp();
        
        }
        if (other.gameObject.tag.ToLower() == "coin")
        {
            pAudio.playCoin();
            Destroy(other.gameObject);
            GM.Instance.score = GM.Instance.score + 10;
            GM.Instance.coinTotal++;

        }
        if (other.gameObject.tag == "pad")
        {

            Destroy(other.gameObject);
            pAudio.playPad();

        }


    }

    
    //void OnTriggerEnter(Collider other) {

    /*if (other.gameObject.name == "rampbottomtrig") {

        GM.vertVel = 2;

    }
    if (other.gameObject.name == "ramptoptrig")
    {

        GM.vertVel = 0;

    }

    if (other.gameObject.name == "exit") {

        GM.lvlCompStatus = "Success!"; 
        SceneManager.LoadScene("LevelComp");
    }
    if (other.gameObject.name == "coin(Clone)")
    {

        Destroy(other.gameObject);
        GM.coinTotal += 1;

    }*/

    // }

    /* IEnumerator stopSlide()
     {

         yield return new WaitForSeconds(.5f);
         horizVel = 0;
     controlLocked = "n";
     } */

    public void FixedUpdate()
    {
        if (moveSpeed <= 7) {
            moveSpeed = moveSpeed + (Time.deltaTime / 4);
        }
        
    }
}

