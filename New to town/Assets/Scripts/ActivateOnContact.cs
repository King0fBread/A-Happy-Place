using UnityEngine;

public class ActivateOnContact : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToActivate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach(GameObject obj in _objectsToActivate)
            {
                obj.SetActive(true);
            }
        }
    }
}
