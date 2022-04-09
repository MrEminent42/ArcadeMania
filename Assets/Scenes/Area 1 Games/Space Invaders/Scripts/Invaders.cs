using UnityEngine;

public class Invaders : MonoBehaviour
{

    public Invader[] prefabs;

    public int rows = 5;
    public int columns = 11;

    public float invaderRowSpacing = 2.0f;
    public float invaderColSpacing = 2.0f;

    private void Awake() {
        for (int row = 0; row < this.rows; row++) {

            float width = invaderColSpacing * (this.columns - 1);
            float height = invaderRowSpacing * (this.rows - 1);
            Vector2 centering = new Vector3(-width/2, -height/2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + row * invaderRowSpacing, 0.0f);

            for (int col = 0; col < this.columns; col++) {
                Invader invader = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * invaderColSpacing;
                invader.transform.position = position;
            }
        }
    }


}
