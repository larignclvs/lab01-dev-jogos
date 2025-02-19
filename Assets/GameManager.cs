using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; // Pontuação do player 1
    public static int PlayerScore2 = 0; // Pontuação do player 2

    public GUISkin layout;              // Fonte do placar
    GameObject theDisco;                 // Referência ao objeto bola

    void Start()
    {
        theDisco = GameObject.FindGameObjectWithTag("Disco"); // Busca a referência da bola
    }

    // Incrementa a pontuação
    public static void Score(string golID)
    {
        if (golID == "GolTop") // Gol do Player 2
        {
            PlayerScore1++;
        }
        else // Gol do Player 1
        {
            PlayerScore2++;
        }
    }

    // Gerência da pontuação e fluxo do jogo
    void OnGUI()
    {
        GUI.skin = layout;

        // Ajustando a posição do placar para a esquerda da tela (vertical)
        GUI.Label(new Rect(50, Screen.height / 2 - 100, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(50, Screen.height / 2 + 50, 100, 100), "" + PlayerScore2);

        // Posicionando o botão de restart no topo da tela
        if (GUI.Button(new Rect(Screen.width / 2 + 120, 20, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theDisco.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }

        // Exibe o vencedor
        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2, 2000, 1000), "PLAYER ONE WINS");
            theDisco.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2, 2000, 1000), "PLAYER TWO WINS");
            theDisco.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}
