using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 2f;
    Vector3 transform = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float d = GameObject.FindGameObjectWithTag("Ball").transform.this[1] - transform.this[1];
        if(d>0){
            move.y = speed * Mathf.Min(d, 1.0f);
        }
        if(d<0){
            move.y = -(speed*Mathf.Min(-d,1.0f));
        }
        transform.position.y += move.y * Time.deltaTime;
    }
}
