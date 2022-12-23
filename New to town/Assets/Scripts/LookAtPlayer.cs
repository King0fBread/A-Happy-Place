using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Transform _transform;
    private void OnEnable()
    {
        _transform = gameObject.transform;
    }
    private void Update()
    {
        _transform.LookAt(_playerTransform, Vector3.up);
    }
}
