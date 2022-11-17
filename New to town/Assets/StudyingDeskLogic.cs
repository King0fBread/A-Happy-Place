using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyingDeskLogic : MonoBehaviour
{
    [SerializeField] private Animator _blackScreenAnim;
    [SerializeField] private Transform _studyingTransfrom;
    [SerializeField] private Transform _playerTransform;
    private PlayerMovement _playerMovement;
    private void Awake()
    {
        _playerMovement = _playerTransform.gameObject.GetComponent<PlayerMovement>();
    }
    private void OnMouseDown()
    {
        _blackScreenAnim.gameObject.SetActive(true);
        _blackScreenAnim.SetTrigger("BlackScreen");
        _playerMovement.StartCoroutine("TempDisableMovement", 4);
        _playerTransform.position = _studyingTransfrom.position;
    }
}
