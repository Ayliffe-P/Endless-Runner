using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effects : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Powerup1" || gameObject.tag == "Powerup2" || gameObject.tag == "Powerup3")
        {
            transform.Rotate(0, 0, 1.5f);
        }
        if (gameObject.tag.ToLower() == "coin") {
            transform.Rotate(0, 1, 0);
            
        }
    }
}
