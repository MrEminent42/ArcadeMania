using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 directionMoved = new Vector3(1,0,0);
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(-2.8f, -3.75f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // if (this.transform.position.x != 3){
        //     this.transform.position = new Vector3(this.transform.position.x + 1.0f, this.transform.position.y, 0.0f);
        //     move += 1;
        // }
        this.transform.position += directionMoved * Time.deltaTime; 
        //this.transform.Translate(Vector3.left * speed * Mathf.Sin(Time.deltaTime));
        // if (this.transform.position.x > -5.0) {
        //     this.transform.Translate(Vector3.left * speed * Mathf.Sin(Time.deltaTime));
        // } else {
        //     this.transform.Translate(Vector3.right * (speed + 5)* Time.deltaTime);
        // }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Barrier"){
            directionMoved.x *= -1;
        }
    }
}
