using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public Transform spawnPoint; // Punto de respawn del jugador
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        currentHealth = maxHealth; // Restablece la salud a su valor máximo
        transform.position = spawnPoint.position; // Mueve al jugador al punto de respawn
        // Agrega aquí cualquier otra lógica necesaria para el respawn, como animaciones o efectos
    }
}
