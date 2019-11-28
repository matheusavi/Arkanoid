using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Destruidor : MonoBehaviour
{
    public GameObject bola;
    public Vector2 Velocidade;
    public Text scoreText;
    public Text lifeText;
    public AudioSource deathSource;


    public Vector2 PosicaoInicial { get; private set; }

    private int score;
    private int lifes = 3;


    private void Start()
    {
        if (bola == null)
            bola = GameObject.FindWithTag("Bola");
        PosicaoInicial = new Vector2(bola.transform.position.x, bola.transform.position.y);
        updateScore();
        updateLifes();
    }

    private async Task OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider.gameObject;

        if (collider.name.ToLower() == "bola")
        {
            lifes--;
            updateLifes();
            if (lifes <= 0)
                await ToggleDeathAsync();
            else
                ResetBolaPosition();
        }
    }

    private async Task ToggleDeathAsync()
    {
        deathSource.Play();
        bola.gameObject.SetActive(false);
        await Task.Delay(3500);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private void ResetBolaPosition()
    {
        bola.transform.position = PosicaoInicial;
        var rigidBody = bola.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, 0);
        rigidBody.AddForce(Velocidade);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bloco"))
        {
            collision.gameObject.SetActive(false);
            score++;
            updateScore();

        }
    }

    private void updateScore()
        => scoreText.text = $"Score: {score}";
    private void updateLifes()
       => lifeText.text = $"Lifes: {lifes}";
}
