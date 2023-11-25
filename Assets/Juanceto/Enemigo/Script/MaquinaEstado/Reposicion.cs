using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposicion : StateMachineBehaviour
{
    [SerializeField]private float velocidadMov;
    private Vector3 puntoInicial;
    private EnemigoVolador enemy;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.gameObject.GetComponent<EnemigoVolador>();
        puntoInicial = enemy.puntoInicial;
        enemy.Girar(puntoInicial); //Quitarlo del Enter si el Punto se mueve
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, puntoInicial, velocidadMov * Time.deltaTime);
        if (animator.transform.position == puntoInicial)
        {
            animator.SetTrigger("Llego");
        }
    }
}
