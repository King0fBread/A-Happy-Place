using UnityEngine;

public class FlashlightObject : MonoBehaviour
{
    [SerializeField] private FlashlightLogic _flashlightLogic;
    private void OnMouseDown()
    {
        _flashlightLogic.AllowFlashlightUse(true);
        gameObject.SetActive(false);
    }
}
