using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counter : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform elec;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag.ToLower() == "player")
        {
            GM.Instance.padCount++;
            Debug.Log(GM.Instance.padCount + " is pad count");
            Instantiate(elec, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), elec.rotation);
        }
        if (GM.Instance.padCount == 3)
        {
            GM.Instance.onBossEnd();
        }
    }
}
