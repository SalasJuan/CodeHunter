using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSpike : MonoBehaviour
{ 
    [SerializeField] private float vida ;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            collision.transform.GetComponent<Player>().PlayerDamaged(10);
        }
    }

}