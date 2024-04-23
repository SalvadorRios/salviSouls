using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruzAplastante : MonoBehaviour
{
    public float lowerPoint = 2.0f;  // La altura m�s baja a la que descender� la plataforma
    public float upperPoint = 5.0f;  // La altura m�s alta a la que ascender� la plataforma
    public float dropSpeed = 10.0f;  // Velocidad de descenso
    public float riseSpeed = 2.0f;   // Velocidad de ascenso
    public float rotationSpeed = 50.0f;  // Velocidad de rotaci�n en grados por segundo

    private bool goingUp = false;    // Estado para controlar la direcci�n del movimiento
    private float startY;            // Posici�n inicial en Y

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        // Movimiento vertical
        float step = (goingUp ? riseSpeed : dropSpeed) * Time.deltaTime; // Velocidad dependiente del estado
        float targetY = goingUp ? upperPoint + startY : lowerPoint + startY; // Determinar el objetivo en Y basado en la direcci�n

        // Mover la plataforma hacia el objetivo
        transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, targetY, step), transform.position.z);

        // Cambiar de direcci�n si se alcanza el objetivo
        if (transform.position.y == targetY)
        {
            goingUp = !goingUp;  // Cambiar la direcci�n del movimiento
        }

        // Rotaci�n continua en el eje Y
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
