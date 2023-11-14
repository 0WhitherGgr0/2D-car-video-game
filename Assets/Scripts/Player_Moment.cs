using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moment : MonoBehaviour
{
    // Variable para asignar el componente Transform del jugador en el Editor de Unity.
    public Transform playertransform; 
    
    // Velocidad de movimiento del jugador. Puede ser ajustada en el Inspector de Unity.
    public float speed = 0.5f;
    
     // Velocidad de rotación del jugador al moverse hacia la derecha o izquierda. Puede ser ajustada en el Inspector de Unity. 
    public float rotationspeed = 1f;

    // Una referencia al componente Score_Manager.
    public Score_Manager scoreValue; 
    public GameObject gameOverPanel;


    // Esta función se llama una vez antes del primer fotograma del juego.
    void Start()
    {
        gameOverPanel.SetActive(false);
        Debug.Log(Time.timeScale); // Imprime el valor actual de Time.timeScale en la consola.
        Time.timeScale = 1;  // Esta línea está comentada, por lo que actualmente no detiene el juego.

    }

    // Esta función se llama una vez por cada fotograma del juego.
    void Update()
    {
        movement(); // Llama a la función movement() que controla el movimiento del jugador.
        Clamp(); // Llama a la función Clamp() para limitar la posición del jugador.
    }

    // Función que maneja el movimiento del jugador.
    void movement()
    {
        if (Input.GetKey(KeyCode.RightArrow))   // Si se mantiene presionada la tecla de flecha derecha, 
        {
            // Mueve al jugador hacia la derecha y rota 90 grados en sentido horario.
            playertransform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            playertransform.rotation = Quaternion.Lerp(playertransform.rotation, Quaternion.Euler(0, 0, 90), rotationspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))  // Si se mantiene presionada la tecla de flecha izquierda, 
        {
            // Mueve al jugador hacia la izquierda y rota 90 grados en sentido antihorario.
            playertransform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            playertransform.rotation = Quaternion.Lerp(playertransform.rotation, Quaternion.Euler(0, 0, 270), rotationspeed * Time.deltaTime);
        }
        if (playertransform.rotation.z != 90)    // Si la rotación no es 90 grados (derecha),
        {
            // Si la rotación no es 90 grados (derecha), la rota 180 grados (volteado).
            playertransform.rotation = Quaternion.Lerp(playertransform.rotation, Quaternion.Euler(0, 0, 180), 10f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))// Si se mantiene presionada la tecla de flecha arriba, 
        {
            // Mueve al jugador hacia arriba.
            playertransform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))        // Si se mantiene presionada la tecla de flecha abajo, 
        {
            // Mueve al jugador hacia abajo.
            playertransform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
    }

    // Función para limitar la posición del jugador en el juego.
    void Clamp()
    {
        // Limita la posición X del jugador entre -1.7 y 1.5.
        // Obtiene la posición actual del jugador.
        Vector3 pos = playertransform.position;
        // Utiliza Mathf.Clamp para asegurarse de que la posición X esté dentro del rango permitido.
        pos.x = Mathf.Clamp(pos.x, -1.7f, 1.5f);
        // Aplica la nueva posición limitada al jugador.
        playertransform.position = pos; 

        // Limita la posición Y del jugador entre -3.5 y 3.5.
        // Obtiene la posición actual del jugador.
        Vector3 pos1 = playertransform.position; 
        // Utiliza Mathf.Clamp para asegurarse de que la posición Y esté dentro del rango permitido.
        pos1.y = Mathf.Clamp(pos1.y, -3.5f, 3.5f);
        // Aplica la nueva posición limitada al jugador.
        playertransform.position = pos1; 

    }

    // Esta función se llama cuando el jugador colisiona con otros objetos en el juego.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Muestra el nombre con el tipo de carro que colisiono
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Cars")// Cuando el jugador colisiona con objetos etiquetados como "Cars" (por ejemplo, coches),
        {
            // se podría pausar el juego al establecer Time.timeScale en 0.
            Time.timeScale = 0;  // Esta línea está comentada, por lo que actualmente no detiene el juego.
            gameOverPanel.SetActive(true);

        }
        if ( collision.gameObject.tag== "Coin")
        {
           
            // Cuando el jugador colisiona con objetos etiquetados como "Coin" (monedas), se incrementa el puntaje.
                scoreValue.score += 10;
                // Además, destruye la moneda que el jugador recoge.
                Destroy(collision.gameObject);
            
        }
    }
}

