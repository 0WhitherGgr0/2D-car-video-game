using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Movement : MonoBehaviour
{
    // Referencia al componente Renderer para el material de la carretera.
    public Renderer meshRenderer;

    // Velocidad de movimiento de la textura de la carretera.
    public float speed = 0.5f;

    void Start()
    {
        // La función Start() se llama una vez antes del primer fotograma del juego,
        // pero en este caso, está vacía y no realiza ninguna acción adicional.
    }

    // Update is called once per frame
    void Update()
    {
       /* Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset = offset + new Vector2(0, speed * Time.deltaTime);
        meshRenderer.material.mainTextureOffset = offset;*/





        /*// El siguiente bloque de código se encarga de mover la textura de la carretera.
        // Esto crea la ilusión de que la carretera se desplaza en el juego.
        // Obtiene la posición actual de la textura de la carretera en el material.
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        // Actualiza la posición de la textura, moviéndola hacia arriba a una velocidad constante.
        offset = offset + new Vector2(0, speed * Time.deltaTime);
        // Aplica la nueva posición de la textura en el material.
        meshRenderer.material.mainTextureOffset = offset;
        */

        meshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);


        // El bloque de código comentado anteriormente y el siguiente son equivalentes.
        // Ambos se utilizan para actualizar la posición de la textura de la carretera.

    }
}
