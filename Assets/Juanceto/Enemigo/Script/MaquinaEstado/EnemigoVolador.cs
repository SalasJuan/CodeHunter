using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVolador : MonoBehaviour, IDaño
{
    [SerializeField] public Transform jugador;
    [SerializeField] private float distancia;
    [SerializeField] private float vida;

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

    public void TomarDaño(float Daño)
    {
        vida -= Daño;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
