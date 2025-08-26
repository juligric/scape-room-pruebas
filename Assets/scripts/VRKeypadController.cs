using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine;

public class VRKeypadController : MonoBehaviour
{
    public TMP_Text displayText;
    public string correctPassword = "1234";
    private string currentInput = "";

    public Transform pivotPuerta;              // Empty pivot de la puerta
    public float velocidadApertura = 90f;      // grados por segundo
    private bool abrir = false;

    public void PressKey(string number)
    {
        currentInput += number;
        UpdateDisplay();
    }

    public void DeleteLast()
    {
        if (currentInput.Length > 0)
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            UpdateDisplay();
        }
    }

    public void Submit()
    {
        if (currentInput == correctPassword)
        {
            abrir = true;   // Activamos la apertura de la puerta
            Debug.Log("Contraseña correcta, abriendo caja");
        }
        else
        {
            Debug.Log("Contraseña incorrecta");
            currentInput = "";
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        displayText.text = currentInput;
    }

    void Update()
    {
        if (abrir && pivotPuerta != null)
        {
            // Gira suavemente la puerta hasta 90°
            pivotPuerta.localRotation = Quaternion.RotateTowards(
                pivotPuerta.localRotation,
                Quaternion.Euler(0, 90, 0), // Cambia eje según cómo esté tu puerta
                velocidadApertura * Time.deltaTime
            );
        }
    }
}
