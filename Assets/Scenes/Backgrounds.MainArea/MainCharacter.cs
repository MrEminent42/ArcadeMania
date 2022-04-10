using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainCharacter : MonoBehaviour
{
    [SerializeField]
    public Text PongT;
    public Text SpaceT;
    public Text SnakeT;
    public Text PlatT;


    

    private Vector2 speed = new Vector2(0.02f,0.02f);
    // Start is called before the first frame update
    void Start()
    {
    PongT.gameObject.SetActive(false);
    SpaceT.gameObject.SetActive(false);
    SnakeT.gameObject.SetActive(false);
    PlatT.gameObject.SetActive(false);
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
    void OnCollisionEnter2D(Collision2D other){
        switch(other.gameObject.tag){
            case "Pong":
                PongT.enabled = true;
                YesorNo("Pong");
                PongT.enabled = false;
                break;
            case "Space":
                SpaceT.enabled = true;
                YesorNo("Space Invaders");
                SpaceT.enabled = false;
                break;
            case "Snake":
                SnakeT.enabled = true;
                YesorNo("Snake");
                SnakeT.enabled = false;
                break;
            case "Platform":
                PlatT.enabled = true;
                YesorNo("Platformer");
                PlatT.enabled = false;
                break;
            case "OldGuy":
                moveToEntrance();
                break;
        }
    }
    void moveToEntrance(){
        transform.Translate(new Vector3(0,-3,0));
    }

    void YesorNo(string filename){
            if(Input.GetKeyDown(KeyCode.Y)){
                   SceneManager.LoadScene(filename);
            }if(Input.GetKeyDown(KeyCode.N)){
                moveToEntrance();
            }
    }
    
    
}
