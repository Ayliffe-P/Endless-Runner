using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void obstaclePassed()
    {
        
        GM.Instance.score = GM.Instance.score + 5;
        GM.Instance.obstacleCount++;
        Debug.Log("+5");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToLower() == "player")
        {
            GM.Instance.obsPassed += obstaclePassed;
            GM.Instance.onObsPassed();
            GM.Instance.obsPassed -= obstaclePassed;
        }
    }
}
