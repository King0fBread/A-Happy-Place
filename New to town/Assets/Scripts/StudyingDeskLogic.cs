using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyingDeskLogic : MonoBehaviour
{
    [SerializeField] private Animator _blackScreenAnim;
    [SerializeField] private Transform _studyingTransfrom;
    [SerializeField] private Transform _playerObjectTransform;
    [SerializeField] private Transform _playerCamTransform;
    private PlayerMovement _playerMovement;
    private void Awake()
    {
        _playerMovement = _playerObjectTransform.gameObject.GetComponent<PlayerMovement>();
    }
    private void OnMouseDown()
    {
        _blackScreenAnim.gameObject.SetActive(true);
        _blackScreenAnim.SetTrigger("BlackScreen");
        _playerMovement.StartCoroutine("TempDisableMovement", 4);
        _playerObjectTransform.position = _studyingTransfrom.position;
        _playerCamTransform.rotation = _studyingTransfrom.rotation;
        Destroy(gameObject);

        PhoneMessagesLogic.instance.ActivateConversation("Third");
    }
}
