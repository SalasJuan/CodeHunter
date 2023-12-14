using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucarachin : MonoBehaviour, IDaño
{
    [Header("Vida y Daño")]
    [SerializeField] private float vida;
    public void TomarDaño(float Daño)
    {
        vida -= Daño;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
