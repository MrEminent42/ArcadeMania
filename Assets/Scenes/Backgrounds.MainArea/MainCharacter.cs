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


    
    private string recentMachine;
    private Vector2 speed = new Vector2(0.02f,0.02f);
    // Start is called before the first frame update
    void Start()
    {
    PongT.gameObject.SetActive(false);
    SpaceT.gameObject.SetActive(false);
    SnakeT.gameObject.SetActive(false);
    PlatT.gameObject.SetActive(false);
    recentMachine = "Nope";
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

        // Debug.Log(recentMachine);

        if(recentMachine != "Nope"){
            if(Input.GetKey(KeyCode.Y)){
                SceneManager.LoadScene(recentMachine);
            }if(Input.GetKey(KeyCode.N)){
                PongT.gameObject.SetActive(false);
                SpaceT.gameObject.SetActive(false);
                SnakeT.gameObject.SetActive(false);
                PlatT.gameObject.SetActive(false);
                recentMachine = "Nope";
                moveToEntrance();}

            }
        }
    
    void OnCollisionEnter2D(Collision2D other){
        switch(other.gameObject.tag){
            case "Pong":
                PongT.gameObject.SetActive(true);
                recentMachine = "Pong";
                break;
            case "Space":
                SpaceT.gameObject.SetActive(true);
                recentMachine = "Space Invaders";
                break;
            case "Snake":
                Debug.Log("Yolo");
                SnakeT.gameObject.SetActive(true);
                recentMachine = "Snake";
                break;
            case "Platform":
                PlatT.gameObject.SetActive(true);
                recentMachine = "Platformer";
                break;
            case "OldGuy":
                moveToEntrance();
                break;
        }
        // PongT.gameObject.SetActive(false);
        // SpaceT.gameObject.SetActive(false);
        // SnakeT.gameObject.SetActive(false);
        // PlatT.gameObject.SetActive(false);

    }
    void moveToEntrance(){
        transform.Translate(new Vector3(0,-3,0));
    }

    // void YesorNo(string filename){
    //     while(!(Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.N))){
    //         }
    //         if(Input.GetKey(KeyCode.Y)){
    //                SceneManager.LoadScene(filename);
    //         }if(Input.GetKey(KeyCode.N)){
    //             moveToEntrance();}
    // }
    
    
}
