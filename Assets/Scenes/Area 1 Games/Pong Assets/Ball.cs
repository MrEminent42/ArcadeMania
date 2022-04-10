using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 3;
    private Rigidbody2D rb;
    private int score = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Launch", 1);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(score);
    }
    void Launch(){
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
        
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Paddle" || other.gameObject.tag == "Player"){
            rb.velocity *= 1.2f;
            if(other.gameObject.tag == "Player"){
                score++;
            }
        }
        if(other.gameObject.tag == "Enemy Goal"){
            Lose();

        }
    }
    
    void Lose(){
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

}
