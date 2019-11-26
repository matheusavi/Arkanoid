using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Vector2 Velocidade;
    public AudioSource orangeSource;
    void Start()
    {
        var rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(Velocidade);
        orangeSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        orangeSource.Play();
    }

}
