using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackProgramerr : MonoBehaviour
{
    public AudioClip ataquesound;
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    [SerializeField] private float TiempoAtaque;
    [SerializeField] private float TiempoSiguienteAtaque;

    private Animator animator;
    private AudioSource audioSource; // Variable para el AudioSource

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Obtener el AudioSource en el mismo GameObject
    }

    private void Update()
    {
        if (TiempoSiguienteAtaque > 0)
        {
            TiempoSiguienteAtaque -= Time.deltaTime;
        }

        //GetButtonDown es = a un getkeyDown es apretar la tecla o el mouse y el fire1 es asignado como click izquierdo
        if (Input.GetButtonDown("Fire1") && TiempoSiguienteAtaque <= 0)
        {
            Golpe();
            TiempoSiguienteAtaque = TiempoAtaque;
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("Ataque");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        // Reproduce el sonido del ataque
        ReproducirSonidoAtaque();
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("EnemigoVolador"))
            {
                colisionador.transform.GetComponent<EnemigoVolador>().TomarDaño(dañoGolpe);
            }
        }
    }

    private void ReproducirSonidoAtaque()
    {
        if (ataquesound != null && audioSource != null)
        {
            audioSource.PlayOneShot(ataquesound);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
