using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruidor : MonoBehaviour
{
    public GameObject bola;
    public Vector2 Velocidade;

    public Vector2 PosicaoInicial { get; private set; }

    private void Start()
    {
        if (bola == null)
            bola = GameObject.FindWithTag("Bola");
        PosicaoInicial = new Vector2(bola.transform.position.x, bola.transform.position.y);
        var rigidBody = bola.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider.gameObject;

        if (collider.name.ToLower() == "bola")
        {
            ResetBolaPosition();
        }
    }

    private void ResetBolaPosition()
    {
        bola.transform.position = PosicaoInicial;
        bola.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        bola.GetComponent<Rigidbody2D>().AddForce(Velocidade);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(collision.gameObject);
    }
}
