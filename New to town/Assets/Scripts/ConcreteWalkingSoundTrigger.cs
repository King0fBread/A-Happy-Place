using UnityEngine;

public class ConcreteWalkingSoundTrigger : MonoBehaviour
{
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _concreteLayer;
    public bool playerIsOnConcrete { get; private set; }
    private Transform _transform;
    private Vector3 _vector3Down;
    private void Awake()
    {
        _transform = gameObject.transform;
        _vector3Down = Vector3.down;
    }
    private void Update()
    {
        GroundCheckForConcrete();
    }
    private void GroundCheckForConcrete()
    {
        playerIsOnConcrete = Physics.Raycast(_transform.position, _vector3Down, _raycastDistance, _concreteLayer);
    }
}
