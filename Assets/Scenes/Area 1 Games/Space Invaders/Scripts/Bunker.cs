using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("COL PROJ");
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader")) {
        Debug.Log("COL HIDE");
            this.gameObject.SetActive(false);
        }
    }
}
