using System;
using Source.Move;
using UnityEngine;


[RequireComponent(typeof(IMove))]
public class ForceImpact : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private IMove _move;

    private void Awake()
    {
        _move = GetComponent<IMove>();
    }

    private void LateUpdate()
    {
        float magnitude = _move.GetCurrentMagnitude();
        float maxSpeed = _move.GetMaxSpeed();
        
        if (_animator) _animator.SetFloat("Velocity", magnitude / maxSpeed);
    }
}
