using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPositionX, checkPointPositionY;

    public Animator animator;
    void Start()
    {
           // agarra las preferencias del usuario y la posicion del checkpoint de la posicion X del personaje
        if (PlayerPrefs.GetFloat("checkPointPositionX")!=0)
        {
            // agarra la posicion del personaje y del checkpoint para volver a aparecer en el checkpoint o en el lugar donde inicio el personaje
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }


    // Agarra la posicion del personaje y verifica donde esta inicialmente o donde se deja aal principio el player de los puntos X y Y
    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX",x);

        PlayerPrefs.SetFloat("checkPointPositionY",y);
    }

    public void PlayerDamaged() 
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}