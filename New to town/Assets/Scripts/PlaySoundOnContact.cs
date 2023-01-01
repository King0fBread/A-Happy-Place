using UnityEngine;

public class PlaySoundOnContact : MonoBehaviour
{
    [SerializeField] private SoundsManager.Sounds _soundToPlay;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundsManager.instance.PlaySound(_soundToPlay);
        }
    }
}
