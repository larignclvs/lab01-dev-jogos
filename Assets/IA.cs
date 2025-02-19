using UnityEngine;

public class IA : MonoBehaviour
{
    public Transform disco; // Referência ao disco (disco)
    public float speed = 5f; // Velocidade da IA
    public float limitX = 3.5f; // Limite para a IA não sair da mesa

    void Update()
    {
        if (disco != null)
        {
            // Calcula a posição-alvo no eixo X, mantendo o Y fixo
            Vector2 targetPosition = new Vector2(Mathf.Clamp(disco.position.x, -limitX, limitX), transform.position.y);
            
            // Move suavemente a IA na direção do alvo
            transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
