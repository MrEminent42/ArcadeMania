using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 directionMoved;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            directionMoved = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            directionMoved = Vector2.left;
        } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            directionMoved = Vector2.down;
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            directionMoved = Vector2.right;
        } 
    }

    void FixedUpdate()
    {
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + directionMoved.x, Mathf.Round(this.transform.position.y) + directionMoved.y, 0.0f);
    }
}
