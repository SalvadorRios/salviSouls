using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{
    public int damageAmount = 20;

    void OnCollisionEnter(Collision collision)
    {
        SaludPlayer playerHealth = collision.collider.GetComponent<SaludPlayer>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
