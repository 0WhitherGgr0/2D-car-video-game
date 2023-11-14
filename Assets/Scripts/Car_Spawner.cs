using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawner : MonoBehaviour
{
    // Un arreglo de GameObjects que representan diferentes tipos de coches.
    public GameObject[] car;

    // Esta función se llama una vez antes del primer fotograma del juego.
    void Start()
    {
        // Inicia la generación continua de coches utilizando una rutina (coroutine).
        StartCoroutine(SpawnCars());
    }

    // Esta función se llama una vez por cada fotograma del juego, pero en este caso no hace nada.
    void Update()
    {
        // Puedes dejarla vacía porque no se necesita para esta funcionalidad específica.
    }

    // Esta función genera un coche de forma aleatoria.
    void cars()
    {
        // Selecciona un índice aleatorio en el arreglo 'car' para obtener un tipo de coche.
        int rand = Random.Range(0, car.Length);

        // Genera una posición X aleatoria dentro de un rango específico.
        float randXPos = Random.Range(-1.65f, 1.5f);

        // Instancia el coche seleccionado en una posición aleatoria en el eje X.
        //**************************************************
        Instantiate(car[rand], new Vector3(randXPos, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 90));
        // La rotación Quaternion.Euler(0, 0, 90) rota el coche 90 grados en el eje Z.
    }

    // Esta función utiliza una rutina para generar coches periódicamente.
    IEnumerator SpawnCars()
    {
        while (true)
        {
            // Espera 3 segundos antes de generar un coche.
            yield return new WaitForSeconds(2);
            // Llama a la función 'cars()' para generar un coche.
            cars();
        }
    }
}
