// using System.Drawing;
// using System.Diagnostics;
// using System.Numerics;
// using System.Threading.Tasks.Dataflow;
// using System.Threading;
// using System.Net.Mail;
// using System;
// using System.ComponentModel.DataAnnotations.Schema;
using UnityEngine;

public class PlayerMovePlatformer : MonoBehaviour
{
    private Vector2 speed = new Vector2(0.02f,0.02f);
    private Rigidbody2D rb2D;
    private int jumps;
    private void Awake(){
        rb2D = transform.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        jumps = 0;
        this.transform.position = new Vector3 (-8.12f, -3.69f, 0.0f);
    }

    // Update is called once per frame
   void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        // float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(speed.x*horizontal,0,0);
        movement = movement - movement*Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Space) && jumps == 0){
            float jumpVel = 5f;
            rb2D.velocity = Vector2.up * jumpVel;
            jumps += 1;
        }
    }

    // private bool IsGrounded(){
    //     float extraHeightText = 0.01f;
    //     Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extends.y + extraHeightText);
    //     Color rayColor;
    //     if (raycastHit.collider != null){
    //         rayColor = Color.green;
    //     } else{
    //         rayColor = Color.red;
    //     }
    //     Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extends.y + extraHeightText));
    //     return raycastHit.collider != null;
    // }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Ground"){
            jumps = 0;
        } else if (other.gameObject.tag == "Castle"){
            Debug.Log("Massive Dubs");
            Start();
        } else if (other.gameObject.tag == "Enemy"){
            Start();
        }
    }
         
}