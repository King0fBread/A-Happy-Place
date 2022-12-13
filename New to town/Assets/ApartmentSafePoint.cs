using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApartmentSafePoint : MonoBehaviour
{
    [SerializeField] private MonsterPersuitLogic _monsterPersuit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _monsterPersuit.gameObject.SetActive(false);
        }
    }
}
