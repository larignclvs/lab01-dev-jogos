using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paleta : MonoBehaviour
{
    public float limitX = 2f;  // Limite lateral (bordas da quadra)
    public float limitTop = 1f;  // Limite superior (altura máxima da paleta)
    public float limitBottom = 0f; // Meio da quadra (a paleta não desce abaixo disso)

    public AudioSource source;

    void Update()
    {
        // Pega a posição do mouse na tela
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        
        // Limita o movimento da paleta no eixo X e Y
        pos.x = Mathf.Clamp(mousePos.x, -limitX, limitX); // Limita lateralmente
        pos.y = Mathf.Clamp(mousePos.y, limitBottom, limitTop); // Limita na sua metade

        // Atualiza a posição da paleta
        transform.position = pos;
    }
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Disco")) 
        {
            source.Play(); 
        }
    }

}
