using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextUpdate : MonoBehaviour
{
    public Text tickets;
    public Button button;

    public void Start() {
        tickets.text = "x00";
        button.onClick.AddListener(GoHome);
    

    }
    public void Update() {
        tickets.text = "x" + UniversalData.getTickets().ToString("00");
    }
    public void GoHome() {
        SceneManager.LoadScene("Arcade Area 1");
    }
}
