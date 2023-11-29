using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemigoVolador : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] public Transform jugador;
    [SerializeField] private float distancia;

    //Punto de partida y donde va a volver
    public Vector3 puntoInicial;
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        puntoInicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        distancia = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("Distancia", distancia);
    }

    public void TomarDaño(float Daño) 
    {
        vida -= Daño;

        if (vida <= 0 )
        {
            Muerte();
        }
    }


    public void Girar(Vector3 objetivo)
    {
        if (transform.position.x < objetivo.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void Muerte()
    {
        Destroy(gameObject);
    }

}
