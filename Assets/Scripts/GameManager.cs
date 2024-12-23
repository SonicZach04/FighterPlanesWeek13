using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject cloud;
    public GameObject powerup;
    public GameObject coinPrefab;  
    public AudioClip powerUp;
    public AudioClip powerDown;
    public AudioClip coinPickupSound;  
    private Player playerScript;

    public int cloudSpeed;

    private bool isPlayerAlive;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI powerupText;
    public TextMeshProUGUI livesText;

    private int score;

    private CoinSpawner coinSpawner;  

    
    void Start()
    {
        player = Instantiate(player, transform.position, Quaternion.identity);
        if (player != null)
        {
            playerScript = player.GetComponent<Player>();
        }
        
        
        InvokeRepeating("CreateEnemyOne", 1f, 3f);
        InvokeRepeating("CreateEnemyTwo",3f, 5f);
        StartCoroutine(CreatePowerup());
        CreateSky();

        score = 0;
        scoreText.text = "Score: " + score;

        isPlayerAlive = true;
        cloudSpeed = 1;

       
        coinSpawner = gameObject.AddComponent<CoinSpawner>();
        coinSpawner.coinPrefab = coinPrefab;
        coinSpawner.coinPickupSound = coinPickupSound;
        coinSpawner.StartCoinSpawning();
    }

    
    void Update()
    {
        if(player !=null){
            livesText.text = "Lives: " + playerScript.lives;
        }
        else if (player == null)
        {
            livesText.text = "Lives: 0";
        }

        Restart();
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOne, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwo, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
        Debug.Log("Instantiated Enemy Two");
    }

    IEnumerator CreatePowerup()
    {
        Instantiate(powerup, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3f, 6f));
        StartCoroutine(CreatePowerup());
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int newScore)
    {
        score += newScore;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isPlayerAlive = false;
        CancelInvoke();
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        cloudSpeed = 0;
    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isPlayerAlive)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void UpdatePowerupText(string whichPowerup)
    {
        powerupText.text = whichPowerup;
    }

    public void PlayPowerUp()
    {
        AudioSource.PlayClipAtPoint(powerUp, Camera.main.transform.position, 0.4f);
    }

    public void PlayPowerDown()
    {
        AudioSource.PlayClipAtPoint(powerDown, Camera.main.transform.position, 0.15f);
    }


}