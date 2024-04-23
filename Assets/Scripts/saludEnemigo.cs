using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saludEnemigo : MonoBehaviour
{
    public int maxHealth = 100; // Salud máxima del enemigo
    private int currentHealth; // Salud actual del enemigo

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la salud
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la salud

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Destruir el enemigo si la salud es 0 o menos
        }
    }
}
