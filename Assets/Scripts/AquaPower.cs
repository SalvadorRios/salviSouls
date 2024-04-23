using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AquaPower : MonoBehaviour
{
    public GameObject projectilePrefab; // Referencia al prefab del proyectil
    public Transform shootingPoint; // Punto desde el cual se disparar�n los proyectiles
    public float shootingForce = 1500f; // Fuerza de disparo del proyectil

    private InputAction shootAction;

    void Awake()
    {
        // Crea la acci�n de disparo y asocia el evento al metodo correspondiente
        shootAction = new InputAction(binding: "<Mouse>/leftButton");
        shootAction.performed += _ => ShootProjectile();
    }

    void OnEnable()
    {
        shootAction.Enable();
    }

    void OnDisable()
    {
        shootAction.Disable();
    }

    void ShootProjectile()
    {
        if (projectilePrefab && shootingPoint)
        {
            // Instancia el proyectil en el punto de disparo
            GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
            // A�ade una fuerza al Rigidbody del proyectil para dispararlo
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            if (projectileRigidbody)
            {
                projectileRigidbody.AddForce(shootingPoint.forward * shootingForce);
            }
        }
    }

}
