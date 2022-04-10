using UnityEngine;
using UnityEngine.SceneManagement;

public class Invaders : MonoBehaviour
{

    public Invader[] prefabs;

    public int rows = 5;
    public int columns = 11;
    public AnimationCurve speed;

    public Projectile missilePrefab;

    public float missileAttackRateSeconds = 1.0f;

    public float invaderRowSpacing = 2.0f;
    public float invaderColSpacing = 2.0f;

    public int amountAlive => this.totalInvaders - this.amountKilled;
    public int amountKilled;
    public int totalInvaders => this.rows * this.columns;
    public float percentKilled => (float)this.amountKilled / (float)this.totalInvaders;

    // Vector3 _direction = Vector2.right;

    private void Awake() {
        // info for centering
        float width = invaderColSpacing * (this.columns - 1);
        float height = invaderRowSpacing * (this.rows - 1);
        Vector2 center = new Vector3(width/2, height/2);
        
        for (int row = 0; row < this.rows; row++) {
            // center the row
            Vector3 rowPosition = new Vector3(-center.x, row * invaderRowSpacing - center.y, 0.0f);

            // space the invaders col
            for (int col = 0; col < this.columns; col++) {
                Invader invader = Instantiate(this.prefabs[row], this.transform);
                invader.onKilled += InvaderKilled; // InvaderKilled() when Invader killed

                Vector3 position = rowPosition;
                position.x += col * invaderColSpacing;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Start() {
        InvokeRepeating(nameof(MaybeShootLaser), this.missileAttackRateSeconds, this.missileAttackRateSeconds);
    }


    private void Update() {
        // this.transform.position += _direction * speed.Evaluate(this.percentKilled) * Time.deltaTime;

        // translate viewport coordinate to world space coordinate
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero); // (0,0,0)
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right); // (1,0,0)


        // loop through every child object that is parented by this Invader base
        // foreach (Transform invader in this.transform) {
        //     // if (!invader.gameObject.activeInHierarchy) continue;

        //     if (_direction == Vector3.right && invader.position.x >= rightEdge.x/2 - 1) {
        //         MoveDown();
        //     } else if (_direction == Vector3.left && invader.position.x <= leftEdge.x/2 + 1) {
        //         MoveDown();
        //     }
        // }
    }

    private void MaybeShootLaser() {

        foreach (Transform invader in this.transform) {
            if (!invader.gameObject.activeInHierarchy) continue;

            if (Random.value < 1 /( (float)this.amountAlive) ) {
                Projectile projectile = Instantiate(this.missilePrefab, invader.position, Quaternion.identity);
                projectile.destroyed += something;
                break;
            }
        }
    }

    // private void MoveDown() {

    //     _direction.x *= -1.0f;

    //     Vector3 position = this.transform.position;
    //     position.y -= 1;
    //     this.transform.position = position;
    // }

    private void InvaderKilled() {
        amountKilled++;

        if (this.amountKilled >= this.totalInvaders) {
            GameObject.Find("Player").GetComponent<Player>().endGame();
        }

    }

    private void something() {

    }

}
