using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    float timer = 0;
    float timeToMove = 0.5f;
    int numOfMovimientos = 0;
    float speed = 0.25f;

    public GameObject enemigo;
    public GameObject enemigoMisil;
    public GameObject enemigoMisilClone;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.playGame)
        {
            timer += Time.deltaTime;
            if (timer > timeToMove && numOfMovimientos < 12)
            {
                transform.Translate(new Vector3(speed, 0, 0));
                timer = 0;
                numOfMovimientos++;
            }
            if (numOfMovimientos == 12)
            {
                transform.Translate(new Vector3(0, -1, 0));
                numOfMovimientos = -1;
                speed = -speed;
                timer = 0;
            }

            fireEnemigoMisil();
        }
    }

    void fireEnemigoMisil ()
    {
        if (Random.Range(0f, 750f) < 1)
        {
            enemigoMisilClone = Instantiate(enemigoMisil, new Vector3(enemigo.transform.position.x, enemigo.transform.position.y - 0.4f, 0), enemigo.transform.rotation) as GameObject;

        }
    }
}
