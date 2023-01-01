using UnityEngine;

public class StopSoundOnDestruction : MonoBehaviour
{
    [SerializeField] private SoundsManager.Sounds _soundToStop;
    private void OnDestroy()
    {
        SoundsManager.instance.StopSound(_soundToStop);
    }
}
