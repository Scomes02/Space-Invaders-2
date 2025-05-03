using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject misilPrefab;

    private GameObject misilActivo;

    [Header("Movimiento")]
    public float velocidad = 5f;

    private void Update()
    {
        if (GameManager.lives > 0)
        {
            Mover();
            Disparar();
        }
    }

    void Mover()
    {
        float moverX = 0f;
        float moverY = 0f;

        if (Input.GetKey(KeyCode.RightArrow)) moverX = -1f;
        if (Input.GetKey(KeyCode.LeftArrow)) moverX = 1f;
        if (Input.GetKey(KeyCode.UpArrow)) moverY = -1f;
        if (Input.GetKey(KeyCode.DownArrow)) moverY = 1f;

        Vector3 direccion = new Vector3(moverX, moverY, 0).normalized;
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    void Disparar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && misilActivo == null)
        {
            Vector3 posicionDisparo = transform.position + new Vector3(0, 0.6f, 0);
            misilActivo = Instantiate(misilPrefab, posicionDisparo, Quaternion.identity);
        }
    }
}
