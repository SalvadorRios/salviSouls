using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruzAplastante : MonoBehaviour
{
    public float lowerPoint = 2.0f;  // La altura más baja a la que descenderá la plataforma
    public float upperPoint = 5.0f;  // La altura más alta a la que ascenderá la plataforma
    public float dropSpeed = 10.0f;  // Velocidad de descenso
    public float riseSpeed = 2.0f;   // Velocidad de ascenso
    public float rotationSpeed = 50.0f;  // Velocidad de rotación en grados por segundo

    private bool goingUp = false;    // Estado para controlar la dirección del movimiento
    private float startY;            // Posición inicial en Y

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        // Movimiento vertical
        float step = (goingUp ? riseSpeed : dropSpeed) * Time.deltaTime; // Velocidad dependiente del estado
        float targetY = goingUp ? upperPoint + startY : lowerPoint + startY; // Determinar el objetivo en Y basado en la dirección

        // Mover la plataforma hacia el objetivo
        transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, targetY, step), transform.position.z);

        // Cambiar de dirección si se alcanza el objetivo
        if (transform.position.y == targetY)
        {
            goingUp = !goingUp;  // Cambiar la dirección del movimiento
        }

        // Rotación continua en el eje Y
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
