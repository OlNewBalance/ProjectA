using System;
using System.Collections.Generic;
using Source.Move;
using UnityEngine;


[RequireComponent(typeof(IMove))]
public class ForceImpact : MonoBehaviour
{
    [SerializeField] private List<Animator> _animators;

    private IMove _move;

    private void Awake()
    {
        _move = GetComponent<IMove>();
    }

    private void LateUpdate()
    {
        float magnitude = _move.GetCurrentMagnitude();
        float maxSpeed = _move.GetMaxSpeed();

        foreach (var animator in _animators)
        {
            if (animator) animator.SetFloat("Velocity", magnitude / maxSpeed);
            
        }
    }
}
