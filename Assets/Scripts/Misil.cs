using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{
    public GameObject misil;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -5 * Time.deltaTime, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemigo")
        {
            Destroy(collision.gameObject);
            Destroy(misil);
            GameManager.playGame = true;
        }
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(misil);
        }

    }
}
