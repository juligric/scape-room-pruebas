using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeLock : MonoBehaviour
{
    public string correctCombination = "1234";
    private string inputCombination = "";
    private bool isUnlocked = false;

    public Transform doorToOpen;  // La tapa que va a girar
    public float openAngle = 90f; // Grados para abrir
    public float openSpeed = 2f;  // Velocidad de apertura

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        if (doorToOpen != null)
        {
            closedRotation = doorToOpen.localRotation;
            openRotation = Quaternion.Euler(openAngle, 0, 0) * closedRotation;
        }
    }

    void Update()
    {
        if (isUnlocked && doorToOpen != null)
        {
            // Interpola la rotación para abrir suavemente
            doorToOpen.localRotation = Quaternion.Slerp(doorToOpen.localRotation, openRotation, Time.deltaTime * openSpeed);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !isUnlocked)
        {
            if (Input.anyKeyDown)
            {
                foreach (char c in Input.inputString)
                {
                    if (char.IsDigit(c))
                    {
                        inputCombination += c;
                        Debug.Log("Input: " + inputCombination);

                        if (inputCombination.Length >= correctCombination.Length)
                        {
                            CheckCombination();
                        }
                    }
                }
            }
        }
    }

    void CheckCombination()
    {
        if (inputCombination == correctCombination)
        {
            isUnlocked = true;
            Debug.Log("Caja fuerte abierta!");
        }
        else
        {
            Debug.Log("Combinación incorrecta");
            inputCombination = "";
        }
    }
}
