using System.Collections;
using UnityEngine;
using UnityEngine.UI;  // Asegúrate de agregar esta línea

public class DialogSystem : MonoBehaviour
{
    public Button activationButton;
    public GameObject dialogBox;
    public UnityEngine.UI.Text dialogText;  // Asegúrate de especificar UnityEngine.UI.Text
    public float typingSpeed = 0.05f;

    private string currentSentence;

    void Start()
    {
        dialogBox.SetActive(false);
        activationButton.gameObject.SetActive(false);
    }

    public void ActivateDialog(string sentence)
    {
        currentSentence = sentence;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        dialogText.text = "";
        foreach (char letter in currentSentence.ToCharArray())
        {
            dialogText.text += letter;
            // Reproduce aquí el sonido de la letra (puedes usar AudioSource.PlayOneShot)
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void ShowActivationButton()
    {
        activationButton.gameObject.SetActive(true);
    }

    public void HideActivationButton()
    {
        activationButton.gameObject.SetActive(false);
    }

    public void StartDialog()
    {
        dialogBox.SetActive(true);
        // Puedes agregar lógica adicional aquí si es necesario
    }
}
