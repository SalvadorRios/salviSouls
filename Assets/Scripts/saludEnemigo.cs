using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saludEnemigo : MonoBehaviour
{
    public int maxHealth = 100; // Salud m�xima del enemigo
    private int currentHealth; // Salud actual del enemigo
    public List<ParticleSystem> particleSystems; // Lista de sistemas de partículas para activar
    public Light destructionLight; // Luz para activar
    public float lightDuration = 1f; // Duración en segundos que la luz estará encendida
    public MeshRenderer meshRenderer;
    public List<SkinnedMeshRenderer> skinnedMeshRenderers = new List<SkinnedMeshRenderer>();
    public AudioClip mySoundEffect;

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la salud
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la salud

        if (currentHealth <= 0)
        {
            TriggerDestructionEffects();
        }
    }
    // Método para activar los efectos
        public void TriggerDestructionEffects()
        {
            AudioManager.Instance.PlaySoundEffect(mySoundEffect);
            destructionLight.transform.parent.position = transform.position; // Establece la posición de la luz
            foreach (var particleSystem in particleSystems)
            {
                particleSystem.Play(); // Inicia cada sistema de partículas
            }
            if(meshRenderer != null)
                meshRenderer.enabled = false;
            StartCoroutine(ActivateLight()); // Comienza la corutina para la luz
            if (skinnedMeshRenderers.Count > 0)
            {
                foreach (var skinnedMeshRenderer in skinnedMeshRenderers)
                {
                    skinnedMeshRenderer.enabled = false;
                }
                
            }
        }
    
        private IEnumerator ActivateLight()
        {
            destructionLight.gameObject.SetActive(true);
            yield return new WaitForSeconds(lightDuration); // Espera por la duración configurada
            destructionLight.gameObject.SetActive(false);
            Destroy(gameObject); 
        }
}
