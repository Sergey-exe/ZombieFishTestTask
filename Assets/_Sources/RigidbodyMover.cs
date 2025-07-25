using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMover : MonoBehaviour
{
    private const string IsMove = nameof(IsMove);
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stopDistance;
    [SerializeField] private float _rotationSpeed; 
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;

    private Transform _target;
    private bool _isInit;
    private bool _isActive;

    public void Update()
    {
        if (_isActive == false)
            return;
        
        Move();
        Rotate();
    }

    public void Init(Transform target)
    {
        _target = target ?? throw new ArgumentNullException(nameof(target));
        
        _isInit = true;
    }

    public void Activate()
    {
        if (_isInit == false)
        {
            Debug.LogError($"{nameof(RigidbodyMover)} has not been init");
            return;
        }
        
        _isActive = true;
    }

    public void Deactivate()
    {
        _isActive = false;
    }

    private Vector3 GetVectorSpeed()
    {
        Vector3 playerSpeed = (_target.position - transform.position).normalized;
        playerSpeed *= _moveSpeed * Time.fixedDeltaTime;

        return playerSpeed;
    }
    
    private void Move()
    {
        float distance = Vector3.Distance(transform.position, _target.position);
        _animator.SetBool(IsMove, true);

        if(distance > _stopDistance) 
            _rigidbody.MovePosition(transform.position + GetVectorSpeed());
    }

    private void Rotate()
    {
        Vector3 direction = (_target.position - _rigidbody.position).normalized;
        
        if (direction.sqrMagnitude == 0)
            return;
        
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion currentRotation = _rigidbody.rotation;
        
        Quaternion newRotation = Quaternion.Slerp(currentRotation, targetRotation, _moveSpeed * Time.fixedDeltaTime);
        
        _rigidbody.MoveRotation(newRotation);
    }
}
