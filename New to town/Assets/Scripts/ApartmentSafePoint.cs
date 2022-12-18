using UnityEngine;

public class ApartmentSafePoint : MonoBehaviour
{
    [SerializeField] private MonsterPersuitLogic _monsterPersuit;
    private bool _persuitIsActive = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _persuitIsActive)
        {
            Destroy(_monsterPersuit.gameObject);
        }
    }
    public void AllowPersuitDestruction()
    {
        _persuitIsActive = true;
    }
}
