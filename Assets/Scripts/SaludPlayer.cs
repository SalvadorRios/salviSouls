using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public Transform spawnPoint; // Punto de respawn del jugador
    private int currentHealth;
    public List<ParticleSystem> particleSystems; 

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        TriggerDestructionEffects(); // Llama al método para activar los efectos
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        currentHealth = maxHealth; // Restablece la salud a su valor m�ximo
        transform.position = spawnPoint.position; // Mueve al jugador al punto de respawn
        // Agrega aqu� cualquier otra l�gica necesaria para el respawn, como animaciones o efectos
        
    }
    
    public void TriggerDestructionEffects()
    {
        particleSystems[0].transform.parent.position = transform.position; // Establece la posición de la luz
        foreach (var particleSystem in particleSystems)
        {
            particleSystem.Play(); // Inicia cada sistema de partículas
                
        }
    }
}
