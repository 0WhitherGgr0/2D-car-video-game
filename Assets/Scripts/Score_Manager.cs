using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score_Manager : MonoBehaviour
{
    public int score = 0; // Puntaje actual del jugador.
    public int highScore; // Puntaje más alto obtenido en la partida actual.
    public static int lastScore = 0; // Puntaje de la partida anterior.
    public Text scoreText; // Texto que muestra el puntaje actual en el juego.
    public Text highScoreText; // Texto que muestra el puntaje más alto.
    public Text lastScoreText; // Texto que muestra el puntaje de la partida anterior.

    // Start se llama una vez antes del primer fotograma del juego.
    void Start()
    {
        // Inicia dos rutinas (coroutines) para actualizar el puntaje y recargar el nivel.
        StartCoroutine(Score());
        StartCoroutine(Reload());

        // Obtiene el puntaje más alto guardado en PlayerPrefs o lo establece en 0 si es la primera partida.
        highScore = PlayerPrefs.GetInt("high_score", 0);

        // Muestra el puntaje más alto y el puntaje de la partida anterior en los textos correspondientes.
        highScoreText.text = "HighScore: " + highScore.ToString();
        lastScoreText.text = "LastScore: " + lastScore.ToString();
    }

    // Update se llama una vez por cada fotograma del juego.
    void Update()
    {
        // Actualiza el texto que muestra el puntaje actual en el juego.
        scoreText.text = score.ToString();

        // Compara el puntaje actual con el puntaje más alto.
        if (score > highScore)
        {
            highScore = score;

            // Guarda el nuevo puntaje más alto en PlayerPrefs.
            PlayerPrefs.SetInt("high_score", highScore);

            // Muestra el nuevo puntaje más alto en la consola de Unity.
            Debug.Log("High Score: " + highScore);
        }
    }

    // Coroutine para actualizar el puntaje continuamente.
    IEnumerator Score()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.8f);
            score = score + 1;

            // Actualiza el puntaje de la partida anterior.
            lastScore = score;
        }
    }

    // Coroutine para recargar el nivel del juego después de un tiempo aleatorio.
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(Random.Range(100, 110));

        // Carga nuevamente el nivel "Game" (reinicia el juego).
        SceneManager.LoadScene("Game");

        // Actualiza el puntaje de la partida anterior.
        lastScore = score;
    }
}
