using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnContact : MonoBehaviour
{
    [SerializeField] private GameObject _objectToActivate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _objectToActivate.SetActive(true);
        }
    }
}
