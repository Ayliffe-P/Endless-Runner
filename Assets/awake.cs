using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awake : MonoBehaviour
{
    public Transform player;
    Vector3 position;
    public Vector3 _positionOffset;
    
    private void Awake()
    {
        gameObject.SetActive(false);

    }
    void Start()
    {
        position = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _positionOffset = new Vector3(gameObject.transform.position.x, 7, 30);
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.position = new Vector3(0,player.position.y,player.position.z) + _positionOffset;

    }
}
