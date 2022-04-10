using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 directionMoved;

    public BoxCollider2D foodSpawnArea;
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
