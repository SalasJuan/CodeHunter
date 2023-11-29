using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //SE REQUIERE AÑADIR ESTA LIBRERÍA MANUALMENTE YA QUE NO VIENE CARGADA POR DEFECTO. SU FUNCIÓN ES QUE, CONTROLA LAS ESCENAS.

public class BotonesMenu : MonoBehaviour
{
    [SerializeField] private GameObject botonpausa; //Crea un campo interactuable llamado "botonpausa" en la sección del script dentro del editor del juego (En este caso donde habrá que arrastrar y soltar el elemento que contenga el botón que pause el juego)
    [SerializeField] private GameObject menupausa; //Crea un campo llamado "menupausa" donde irá en este caso insertado el objeto que contenga el fondo del menú de pausa junto con sus botones.

    //AVISO: El script utilizado para controlar el menú in-game es el mismo que el que se utiliza en el menú principal, por lo que estas dos casillas también aparecerán en el campo del script insertado al botón de iniciar juego (ya que, obviamente, es el mismo script en ambas escenas) Sin embargo no tendrán utilidad alguna, por lo que no debe tocarse. Se entenderá mejor más adelante.
    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject ConfigurationMenu;
    [SerializeField] private GameObject Creditos;
    [SerializeField] private GameObject SeleccionarMundo;
    /////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void Pausar() //Método que pausa el juego.
    {

        Debug.Log("Acción: Menu Pausa"); //Envía un mensaje debug a la consola, no afecta nada en el juego.
        Time.timeScale = 0f; //Establece el paso del tiempo dentro del juego a 0, es decir, estará totalmente pausado.
        botonpausa.SetActive(false); //El campo que creamos antes, el elemento que hayamos arrastrado dentro, lo volverá "inactivo", lo ocultará.
        menupausa.SetActive(true); //Reactivará el elemento dentro del campo llamado "menupausa" si este estaba inactivo.

        //Con este código se puede entender que, cuando se ejecuta el método "Pausar", el tiempo del juego es establecido en 0. luego, el botón que se presionó para acceder al menú desaparecerá, ya que si, estando en el editor, se arrastró este elemento (Botón de pausa) a la casilla "botonpausa" del campo de este script que ha sido creado con "SerializeField", y el cual indica que su visibilidad será desactivada (SetActive(false)), ocurrirá esto. A su vez, aparecerá el panel del menú de pausa, ya que si se arrastró a la casilla "menupausa" el elemento que contiene el panel del menú de pausa donde están todos los botones, aparecerá porque se le indicó que establezca su visivilidad en true (Por defecto el panel tiene que tener la visivilidad desactivada, lo cual se puede hacer desde el editor).


    }

    public void Reanudar()  //Este método reanudará el juego si este se encontraba pausado.
    {

        Debug.Log("Acción: Menu Pausa");
        Time.timeScale = 1f; //Establece el tiempo del juego en 1, lo cual significa que correrá a velocidad normal.
        botonpausa.SetActive(true); //Establecerá la visibilidad de lo que haya en la casilla llamada "botonpausa" en true (Habiendo leído lo anterior, debería estar insertado el elemento del botón que alterna el menú de pausa estando in-game)
        menupausa.SetActive(false); //Establece la visivilidad del panel del menú en false (Si es que el elemento del panel de pausa, que contiene todos los botones, ha sido arrastrado a la casilla "menupausa" del campo de este script antes)


    }
    public void Play() //Método que se usa en la escena del menú principal para poder iniciar el juego.
    {
        SceneManager.LoadScene(3); //Le indica al gestor de escenas que debe cargar la escena 1, en la escena 1 se ubica el juego de testeo.
        Time.timeScale = 1f; //El tiempo es establecido a 1 (En marcha) al comenzar el juego porque, si se salió al menú mediante el botón de ir al menú, el cual se encuentra en el menú de pausa, esto significa que se pausó el juego antes, por lo que el tiempo permanecerá en 0 hasta que por medio de otra línea de código sea establecido a 1. Si se entra al juego después de haber salido desde el menú y sin establecer el tiempo a 1, este seguirá pausado porque seguirá en 0 desde la vez que se salió al menú.

    }

    public void StopPlay() //Método que se usa in-game, encontrado en el botón de salir cuando se alterna el menú de pausa.
    {

        SceneManager.LoadScene(0); //Le indica al gestor de escenas que cargue la escena 0. En esta escena se ubica el menú de inicio.
    }

    public void SelectWorld() //SELECCIONAR MUNDO
    {
        MainMenu.SetActive(false);
        SeleccionarMundo.SetActive(true);
        Debug.Log("Boton Selección Niveles");

    }

    public void ConfigurationsMenu() //CONFIGURACIONES
    {
        MainMenu.SetActive(false);
        ConfigurationMenu.SetActive(true);
    }

    public void VolverDeConfiguraciones() //(VOLVER DE CONFIGURACIONES)
    {
        MainMenu.SetActive(true);
        ConfigurationMenu.SetActive(false);
        Debug.Log("Boton Volver al menu principal");
    }

    public void VolverDeSeleccion() //(VOLVER DE SELECCIÓN DE NIVELES)
    {
        MainMenu.SetActive(true);
        SeleccionarMundo.SetActive(false);
    }
}
