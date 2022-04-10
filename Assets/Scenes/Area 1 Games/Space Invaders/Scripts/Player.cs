using UnityEngine;

public class Player : MonoBehaviour
{

    public Projectile laserPrefab;

    public float speed = 5f;

    private bool _activeLaser = false;

    private void Update() {
        // GetKey: return true every frame that key is pressed
        // GetKeyDown: only returns true the first frame key is pressed until release
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero); // (0,0,0)
            if (!(this.transform.position.x <= leftEdge.x + 2)) {
                this.transform.position += Vector3.left * this.speed * Time.deltaTime;
            }
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            
            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right); // (1,0,0)
            if (!(this.transform.position.x >= rightEdge.x - 2)) {
                this.transform.position += Vector3.right * this.speed * Time.deltaTime;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void Shoot() {
        if (!_activeLaser) {
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed; 
            _activeLaser = true;
        }
    }

    private void LaserDestroyed() {
        this._activeLaser = false;
    }
}
