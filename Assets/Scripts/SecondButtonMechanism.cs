using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondButtonMechanism : MonoBehaviour
{
    public ButtonMechanism buttonMechanism; 
    public Vector3 newTargetPosition;     

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alien"))
        {
            Debug.Log("Segundo botón activado por: " + collision.name);
            buttonMechanism.ResetBlock(newTargetPosition);
        }
    }
}

