using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentarPeca : MonoBehaviour

    
{
    Animator animator;
    float axis;
    Vector2 velocidade;
    bool ladoDireito = true;
    public float MaxVelocidade = 10;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        axis = Input.GetAxis("Horizontal");

        if (axis > 0 && !ladoDireito)
            Vire();

        if (axis < 0 && ladoDireito)
            Vire();

        velocidade = new Vector2(axis * MaxVelocidade, GetComponent<Rigidbody2D>().velocity.y);

        GetComponent<Rigidbody2D>().velocity = velocidade;
    }

    void Update()
    {

    }

    void Vire()
    {
        ladoDireito = !ladoDireito;

        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

        transform.localScale = novoScale;
    }
   
}

