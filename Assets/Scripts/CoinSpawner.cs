using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 2f;
    public float destroyDelay = 3f;
    public AudioClip coinPickupSound;

    public void StartCoinSpawning()
    {
        
        InvokeRepeating("SpawnCoin", 0f, spawnInterval);
    }

    void SpawnCoin()
    {
        
        float randomX = Random.Range(-9f, 9f);
        float randomY = Random.Range(4f, 7f);

        
        GameObject coin = Instantiate(coinPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);

       
        Coin coinScript = coin.GetComponent<Coin>();

        
        coinScript.Initialize(this, destroyDelay);

        
        coinScript.ActivateCoin();

        
        Destroy(coin, destroyDelay);
    }

    public void AddScore(int score)
    {
        
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EarnScore(score);
    }
}
