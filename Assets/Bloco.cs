using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    public Rigidbody2D Rigidbody;

    public BoxCollider2D Collider;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody.constraints = new RigidbodyConstraints2D();
        Collider.isTrigger = true;
    }
}
