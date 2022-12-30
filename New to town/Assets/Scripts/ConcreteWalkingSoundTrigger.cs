using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteWalkingSoundTrigger : MonoBehaviour
{
    [HideInInspector] public bool playerIsOnConcrete { get; private set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("player on concrete");
            playerIsOnConcrete = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsOnConcrete = false;
        }
    }
}
