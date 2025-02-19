using UnityEngine;

public class PlayerIA : MonoBehaviour
{
    public float speed = 5f;   // Velocidade da IA
    public Transform disco;     // Referência à bola
    public float limitX = 7f;  // Limite lateral (bordas da quadra)
    public float limitTop = 4f;  // Limite superior (altura máxima da IA)
    public float limitBottom = 0f; // Meio da quadra (IA não desce abaixo disso)
    void Start()
    {
    GameObject objDisco = GameObject.FindGameObjectWithTag("Disco");
    if (objDisco != null)
    {
        disco = objDisco.transform; 
    }
    else
    {
        Debug.LogError("Objeto com a tag 'Disco' não encontrado!");
    }
    }
    void Update()
{
    if (disco != null) 
    {
        // Pega a posição alvo, mas com um pequeno erro
        float erro = Random.Range(-0.5f, 0.5f); // Adiciona erro no movimento
        Vector3 targetPosition = new Vector3(disco.position.x + erro, transform.position.y, transform.position.z);

        // Faz a IA se mover suavemente, simulando uma reação mais lenta
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, 0.05f); 

        // Mantém a IA dentro dos limites da quadra
        newPosition.x = Mathf.Clamp(newPosition.x, -limitX, limitX); 
        newPosition.y = Mathf.Clamp(newPosition.y, limitBottom, limitTop); 

        transform.position = newPosition;
    }
}
}
