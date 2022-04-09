using UnityEngine;

public class Invaders : MonoBehaviour
{

    public Invader[] prefabs;

    public int rows = 5;
    public int columns = 11;
    public float speed = 1.0f;

    public float invaderRowSpacing = 2.0f;
    public float invaderColSpacing = 2.0f;

    private Vector3 _direction = Vector2.right;

    private void Awake() {
        // info for centering
        float width = invaderColSpacing * (this.columns - 1);
        float height = invaderRowSpacing * (this.rows - 1);
        Vector2 center = new Vector3(-width/2, -height/2);
        
        for (int row = 0; row < this.rows; row++) {
            // center the row
            Vector3 rowPosition = new Vector3(center.x, center.y + row * invaderRowSpacing, 0.0f);

            // space the invaders col
            for (int col = 0; col < this.columns; col++) {
                Invader invader = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * invaderColSpacing;
                invader.transform.localPosition = position;
            }
        }
    }


    private void Update() {
        this.transform.position += _direction * speed * Time.deltaTime;

        // translate viewport coordinate to world space coordinate
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right); // (1,0,0)


        // loop through every child object that is parented by this Invader base
        foreach (Transform invader in this.transform) {
            if (!invader.gameObject.activeInHierarchy) continue;

            if (_direction == Vector3.right && invader.position.x >= rightEdge.x - 1) {
                MoveDown();
            } else if (_direction == Vector3.left && invader.position.x <= leftEdge.x + 1) {
                MoveDown();
            }
        }
    }

    private void MoveDown() {

        _direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1;
        this.transform.position = position;
    }

}
