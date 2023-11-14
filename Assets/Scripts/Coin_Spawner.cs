using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawner : MonoBehaviour
{
    // Referencia al prefab de la moneda (el objeto que se instanciará).
    public GameObject Spawner;

    // Esta función se llama una vez antes del primer fotograma del juego.
    void Start()
    {
        // Inicia la generación continua de monedas utilizando una rutina (coroutine).
        StartCoroutine(CoinSpawner());
    }

    // Esta función se llama una vez por cada fotograma del juego, pero en este caso no hace nada.
    void Update()
    {
        // Puedes dejarla vacía porque no se necesita para esta funcionalidad específica.
    }

    // Esta función genera una moneda en una posición aleatoria.
    void CoinSpawn()
    {
        // Genera una posición X aleatoria dentro de un rango específico.
        float rand = Random.Range(-1.65f, 1.5f);

        // Instancia la moneda en la posición aleatoria en el eje X.
        Instantiate(Spawner, new Vector3(rand, transform.position.y, transform.position.z), Quaternion.identity);
    }

    // Esta función utiliza una rutina para generar monedas periódicamente.
    IEnumerator CoinSpawner()
    {
        while (true)
        {
            // Genera un tiempo de espera aleatorio entre 10 y 20 segundos antes de generar una moneda.
            //cambio en el rango de ttiempo
            int time = Random.Range(5,10);
            yield return new WaitForSeconds(time);

            // Llama a la función 'CoinSpawn()' para generar una moneda.
            CoinSpawn();
        }
    }
}
