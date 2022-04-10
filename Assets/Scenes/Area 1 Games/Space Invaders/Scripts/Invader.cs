using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;

    public float animationTime = 1f;

    public System.Action onKilled;

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    public void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite() {

        _animationFrame++;

        if (_animationFrame >= this.animationSprites.Length) {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];

    }

    private void OnTriggerEnter2D(Collider2D other) {
        // check that colliding object is laser
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser")) {
            this.onKilled.Invoke();
            this.gameObject.SetActive(false);
        }
    }

}
