using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private Vector2 speed = new Vector2(0.02f,0.02f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(speed.x*horizontal, speed.y*vertical, 0);

        movement = movement - movement * Time.deltaTime;
        if((vertical<8 && vertical>-8) && (horizontal<4 && horizontal>-4)){
            transform.Translate(movement);
        }
    }
}
