using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp1 : MonoBehaviour
{


    void Start()
    {

    }




    public void unsubscribe()
    {



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToLower() == "player")
        {
            GM.Instance.powerUp1Activate();
        }




    }
}
  

