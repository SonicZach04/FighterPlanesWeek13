using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinSpawner spawner;
    private AudioSource audioSource;

    
    public void Initialize(CoinSpawner spawner, float lifetime)
    {
        this.spawner = spawner;
        audioSource = gameObject.AddComponent<AudioSource>();  

        
        gameObject.SetActive(false);  
        Destroy(gameObject, lifetime);  
    }

    
    public void ActivateCoin()
    {
        gameObject.SetActive(true);  
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  
        {
            spawner?.AddScore(1);  

            
            if (spawner.coinPickupSound != null)
            {
                audioSource.PlayOneShot(spawner.coinPickupSound);  
            }

            Destroy(gameObject);  
        }
    }
}