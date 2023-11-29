using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRadius = 2f;
    public LayerMask interactableLayer;
    public DialogSystem dialogSystem;

    void Update()
    {
        // Verificar si el jugador presiona clic derecho
        if (Input.GetMouseButtonDown(1))
        {
            // Verificar si hay algo interactuable cerca
            Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, interactionRadius, interactableLayer);

            if (hitCollider != null)
            {
                // Activar el diálogo
                dialogSystem.ActivateDialog("Hola, soy un diálogo de ejemplo.");
                dialogSystem.StartDialog();
            }
        }
    }
}
