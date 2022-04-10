using System.Globalization;
// using System.Reflection.PortableExecutable;
using System.Diagnostics;
using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    private Vector2 directionMoved;
    private List <Transform> body;

    public BoxCollider2D foodSpawnArea;
    public Transform prefab;
    void Start()
    {
        Position();
        int startingDirection = Random.Range(1,4);
        switch (startingDirection){
            case 1:
            directionMoved = Vector2.up;
            break;

            case 2:
            directionMoved = Vector2.right;
            break;

            case 3:
            directionMoved = Vector2.down;
            break;

            case 4:
            directionMoved = Vector2.left;
            break;
        }

        body = new List<Transform>();
        body.Add(this.transform);
    }


    void Position()
    {
        Bounds bounds = this.foodSpawnArea.bounds;

        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

        this.transform.position = new Vector3(x,y,0.0f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            if (directionMoved == Vector2.down && body.Count != 1) {
                directionMoved = Vector2.down;
            } else{
                directionMoved = Vector2.up;
            }
        } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            if (directionMoved == Vector2.right && body.Count != 1) {
                directionMoved = Vector2.right;
            } else{
                directionMoved = Vector2.left;
            }
        } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            if (directionMoved == Vector2.up && body.Count != 1) {
                directionMoved = Vector2.up;
            } else{
                directionMoved = Vector2.down;
            }
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            if (directionMoved == Vector2.left && body.Count != 1) {
                directionMoved = Vector2.left;
            } else{
                directionMoved = Vector2.right;
            }
        } 
        
    }

    void FixedUpdate()
    {   
        Vector3 oldpos = new Vector3(this.transform.position.x - directionMoved.x * 4, this.transform.position.y - directionMoved.y *4, 0);
        UnityEngine.Debug.Log("Moving head " + this.transform.position + " to " + new Vector3(Mathf.Round(this.transform.position.x) + directionMoved.x, Mathf.Round(this.transform.position.y) + directionMoved.y, 0.0f));
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + directionMoved.x, Mathf.Round(this.transform.position.y) + directionMoved.y, 0.0f);
        

        for (int i = body.Count - 1; i > 0; i--) {
            UnityEngine.Debug.Log("Moving " + body[i].name + " to " + body[i].transform.position + " to " + oldpos);
        
            Vector3 temp = new Vector3(body[i].transform.position.x, body[i].transform.position.y, 0f);
            body[i].transform.position = new Vector3(oldpos.x, oldpos.y, 0);
            oldpos = temp;
        }

    }

    void Grow(){
        Transform bodyAddition = Instantiate(this.prefab);
        bodyAddition.name = "Snake Body " + body.Count;
        // bodyAddition.position = body[body.Count-1].position;
        bodyAddition.position = new Vector3(Mathf.Round(this.transform.position.x) - directionMoved.x * 4, Mathf.Round(this.transform.position.y) - directionMoved.y * 4, 0.0f);
        UnityEngine.Debug.Log("new " + bodyAddition.position + " vs snake head " + this.transform.position);
        body.Add(bodyAddition);
    }

    void resetGame(){
        for (int i = 1; i < body.Count; i ++ ){
            Destroy(body[i].gameObject);
         }
        body.Clear();
        body.Add(this.transform);
        Start();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log("Collide " + this.name + " with " + other.name);
        if (other.tag == "Food"){
            // for (int i = 0; i < 5; i++){
                Grow();
            // }
        } else if (other.tag == "Wall") {
            UnityEngine.Debug.Log("Collide indented " + this.name + " with " + other.name);
            resetGame();
        }
    }
    
}
