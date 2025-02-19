using UnityEngine;
using System.Collections;
public class GolDetector : MonoBehaviour {

    // Verifica colisões da bola nas paredes
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.tag == "Disco")
        {
            string golName = transform.name;
            GameManager.Score(golName);
            hitInfo.gameObject.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }
}
