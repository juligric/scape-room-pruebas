
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class VRKeypadController : MonoBehaviour
{
    public TMP_Text displayText;               // Texto para mostrar la contraseña ingresada
    public string correctPassword = "1234";    // Contraseña correcta
    private string currentInput = "";          // Contraseña ingresada hasta el momento

    public GameObject box;                      // Objeto que se ocultará si la contraseña es correcta

    // Se llama cuando se presiona un botón numérico
    public void PressKey(string number)
    {
        Debug.Log("Tecla presionada: " + number);
        currentInput += number;
        UpdateDisplay();
    }

    // Se llama para borrar el último carácter ingresado
    public void DeleteLast()
    {
        if (currentInput.Length > 0)
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            Debug.Log("Borrado último carácter");
            UpdateDisplay();
        }
        else
        {
            Debug.Log("Nada para borrar");
        }
    }

    // Se llama cuando se presiona el botón Enter
    public void Submit()
    {
        Debug.Log("Intento de envío: " + currentInput);
        if (currentInput == correctPassword)
        {
            Debug.Log("Contraseña correcta");
            OpenBox();
        }
        else
        {
            Debug.Log("Contraseña incorrecta");
            currentInput = "";
            UpdateDisplay();
        }
    }

    // Actualiza el texto mostrado en pantalla
    private void UpdateDisplay()
    {
        displayText.text = currentInput;
    }

    // Acción para abrir/ocultar la caja
    private void OpenBox()
    {
        if (box != null)
        {
            box.SetActive(false); // Desactiva la caja
            Debug.Log("Caja abierta (oculta)");
        }
        else
        {
            Debug.LogWarning("El objeto 'box' no está asignado en el inspector");
        }
    }
}

