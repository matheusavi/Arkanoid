using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Vector2 Velocidade;

    void Start()
    {
        var rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(Velocidade);
    }

}
