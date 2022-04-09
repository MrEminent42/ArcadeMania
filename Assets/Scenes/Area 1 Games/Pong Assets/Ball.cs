using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Rigidbody2D rb;

    void Start()
    {
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Launch(){
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }
}
