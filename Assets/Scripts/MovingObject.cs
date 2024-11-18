using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{

    public int whatAmI;
    private GameManager gameManager;
    private int reverse = 1;

    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

   
    void Update()
    {
        if (whatAmI == 1) 
        {
            
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 8f);
        } else if (whatAmI == 2)
        {
            
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 4f);
        } else if (whatAmI == 3)
        {
            
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * Random.Range(3f, 6f) * gameManager.cloudSpeed);
        } else if (whatAmI == 4)
        {
            
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 6f);
        } else if (whatAmI == 5)
        {
            
            transform.Translate(new Vector3(1 * reverse, 1, 0) * Time.deltaTime * 3f);
        }

        if ((transform.position.y > 9f || transform.position.y <= -9f) && whatAmI != 3)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y <= -9f && whatAmI == 3)
        {
            transform.position = new Vector3(Random.Range(-12f, 12f), 9f, 0);
        }
        
         if (whatAmI == 5 && transform.position.x > 11.5)
        {
            reverse *= -1;
        } else if (whatAmI == 5 && transform.position.x < -11.5)
        {
            reverse *= -1;
        }
    }
}
