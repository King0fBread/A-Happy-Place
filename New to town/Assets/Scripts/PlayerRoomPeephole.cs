using UnityEngine;

public class PlayerRoomPeephole : MonoBehaviour
{
    [SerializeField] private GameObject _peepCamera;
    [SerializeField] private ToggleItemsUse _itemsToggle;

    [SerializeField] private GameObject _monsterObject;
    private bool _monsterIsOutside = false;
    private bool _canPeep = true;
    private void OnMouseDown()
    {
        if (!_canPeep) return;

        _peepCamera.SetActive(true);
        _itemsToggle.ToggleFlashlightState(false);
        _itemsToggle.ToggleFlashlightPermission(false);
        _itemsToggle.ManuallyDisablePhone();

        if (_monsterIsOutside)
        {
            PhoneMessagesLogic.instance.ActivateConversation("Seventh");
            DisableFuturePeeping();
        }
    }
    private void OnMouseUp()
    {
        _peepCamera.SetActive(false);

        _itemsToggle.ToggleFlashlightPermission(true);
        _itemsToggle.TryManuallyEnablePhone();

        if (_monsterIsOutside)
        {
            _monsterIsOutside = false;
            _monsterObject.SetActive(false);
        }
    }
    private void DisableFuturePeeping()
    {
        _canPeep = false;
    }
    public void SetMonsterOutside()
    {
        _monsterIsOutside = true;
        _monsterObject.SetActive(true);
    }
    public void EnablePeeping()
    {
        _canPeep = true;
    }
}
