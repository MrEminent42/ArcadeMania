using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;

    public float animationTime = 1f;

    public System.Action onKilled;

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    private Vector3 _direction;
    
    // private Invader parent;
    // private GameObject parent => this.transform.parent.gameObject;
    // private Invaders parent => this.GetComponentInParent();
    private Invaders parent => transform.parent.GetComponent<Invaders>();

    public void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (Random.value > 0.5) _direction = Vector2.right;
        else _direction = Vector2.left;
    }

    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void Update() {
        if (!this.gameObject.activeInHierarchy) return;

        // Invader parent = transform.parent.GetComponent<Invader>();
        // Debug.Log("p name " + parent.name);
        this.transform.position += this._direction * parent.speed.Evaluate(parent.percentKilled) * Time.deltaTime;
        
        // translate viewport coordinate to world space coordinate
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero); // (0,0,0)
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right); // (1,0,0)
    
        if (_direction == Vector3.right && this.transform.position.x >= rightEdge.x/2 - 1) {
                MoveDown();
            } else if (_direction == Vector3.left && this.transform.position.x <= leftEdge.x/2 + 1) {
                MoveDown();
            }
    
    }

    private void AnimateSprite() {

        _animationFrame++;

        if (_animationFrame >= this.animationSprites.Length) {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];

    }
    
    private void MoveDown() {

        _direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1;
        this.transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // check that colliding object is laser
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser")) {
            this.onKilled.Invoke();
            this.gameObject.SetActive(false);
        }
    }

}
