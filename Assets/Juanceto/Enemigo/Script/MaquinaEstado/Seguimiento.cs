using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Seguimiento : StateMachineBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float tiempoSeguimiento; //Tiempo que puede estar alejado del Player
    private float tiempoRestante;

    private Transform jugador;
    private EnemigoVolador enemigo;

    //Cuando se entra al estado actual se Activa
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tiempoRestante = tiempoSeguimiento;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemigo = animator.gameObject.GetComponent<EnemigoVolador>();
    }

    // Mientras se encuentre en el estado
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Se desplaza desde la posicion actual a la del jugador 
        animator.transform.position = Vector2.MoveTowards(animator.transform.position,jugador.position, velocidadMovimiento * Time.deltaTime);
        enemigo.Girar(jugador.position);
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            animator.SetTrigger("Volver");
        }
    }

    // Entra cuando esta Transicionando hacia otro estado
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
