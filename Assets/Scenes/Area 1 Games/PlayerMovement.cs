using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Vector2 speed = new Vector2(50, 50);


    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(0, speed.y*vertical, 0);

        movement = movement - movement * Time.deltaTime;
        if(vertical<3.66 && vertical>-3.66){
            transform.Translate(movement);
        }
    }


}
