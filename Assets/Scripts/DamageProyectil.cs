using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageProyectil : MonoBehaviour
{
    public int damage = 10; // Da�o que el proyectil infligir�

    void OnCollisionEnter(Collision collision)
    {
        saludEnemigo enemyHealth = collision.collider.GetComponent<saludEnemigo>(); // Intentar obtener el componente EnemyHealth del objeto con el que colisiona

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage); // Aplicar da�o si el objeto tiene el componente EnemyHealth
            Destroy(gameObject); // Destruir el proyectil tras infligir da�o
        }
    }
}
