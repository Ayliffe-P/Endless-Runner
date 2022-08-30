using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp2 : MonoBehaviour
{
    void Start()
    {
        
    }
  
    private void OnTriggerEnter(Collider other)
    {
        //  Debug.Log("triggered");
        if (other.tag.ToLower() == "player")
        {
            GM.Instance.powerUp2Activate();
        }
        
    }
}
