using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D foodSpawnArea;
    // Start is called before the first frame update
    void Start()
    {
        Position();
    }
    void Position()
    {
        Bounds bounds = this.foodSpawnArea.bounds;

        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

        this.transform.position = new Vector3(x,y,0.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Snake"){
            Position();
        }
    }
}
