using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Moment : MonoBehaviour
{
    // Variable pública que permite asignar un Transform en el Editor de Unity.
    public Transform cartransform;

    // Variable pública que representa la velocidad del movimiento hacia abajo.
    public float speed = 5;

    // Esta función se llama una vez cuando se inicializa el objeto del juego.
    void Start()
    {
        // Obtén y almacena el componente Transform del objeto.
        cartransform = GetComponent<Transform>();
    }



    
    /*
    Esta función se llama una vez por cada fotograma del juego.
    Update()controla el movimiento y la posible destrucción
    de un objeto del juego que no es movido por el jugador.
    */
    void Update()
    {
        // Actualiza la posición del coche, moviéndolo hacia abajo en el eje Y.
        cartransform.position -= new Vector3(0, speed * Time.deltaTime, 0);

        // Comprueba si la posición Y del coche es menor o igual a -10.
        if (cartransform.position.y <= -10)
        {
            // Si es así, destruye el objeto del juego (el coche).
            Destroy(gameObject);
        }
    }
}

