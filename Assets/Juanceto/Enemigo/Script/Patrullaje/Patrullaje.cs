using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float VelMovimiento;
    public LayerMask capaAbajo;
    public LayerMask capaFrente;
    public float DistanciaAbajo;
    public float DistanciaFrente;
    public Transform DeteccionSuelo;
    public Transform DeteccionFrente;
    public bool InfoAbajo;
    public bool InfoFrente;
    public bool Derecha = true;

    void Update()
    {
        rb2d.velocity = new Vector2(VelMovimiento, rb2d.velocity.y);

        InfoAbajo = Physics2D.Raycast(DeteccionSuelo.position, transform.up * -1, DistanciaAbajo, capaAbajo);
        InfoFrente = Physics2D.Raycast(DeteccionFrente.position, transform.right, DistanciaFrente, capaFrente);

        if (InfoFrente || !InfoAbajo)
        {
            Girar();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(DeteccionSuelo.transform.position, DeteccionSuelo.transform.position + transform.up * -1 * DistanciaAbajo);
        Gizmos.DrawLine(DeteccionFrente.transform.position, DeteccionFrente.transform.position + transform.right * DistanciaFrente);
    }

    public void Girar()
    {
        Derecha = !Derecha;
        transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y + 180,0);
        VelMovimiento *= -1;
    }

}
