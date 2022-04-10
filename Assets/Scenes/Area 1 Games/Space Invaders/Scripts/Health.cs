using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Player player;
    public int health => player.getHealth();
    public int numOfHearts;

    public Image[] hearts;
    public Sprite heart;

    public void Update() {
        for (int i = 0; i < hearts.Length; i++) {
            hearts[i].enabled = i < health;
        }
    }

}
