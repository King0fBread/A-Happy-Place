using UnityEngine;

public class DenyFlashlightOnHover : MonoBehaviour
{
    [SerializeField] private FlashlightLogic _flashlightLogic;
    private void OnMouseEnter()
    {
        Debug.Log("over");
        _flashlightLogic.ToggleFlashlightPermisson(false);
    }
    private void OnMouseExit()
    {
        Debug.Log("out");
        _flashlightLogic.ToggleFlashlightPermisson(true);
    }
}
