using UnityEngine;

public class PlayerMovePlatformer : MonoBehaviour
{
    private Vector2 directionMoved;
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3(-11.0f,-4.0f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
                directionMoved = Vector2.left;
            } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
                directionMoved = Vector2.right;
        } 
            }
        } 
