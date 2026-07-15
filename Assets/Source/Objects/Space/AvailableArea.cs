using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class AvailableArea : MonoBehaviour
{
    private Transform _playerPosition;
    private Transform _spaceObjectPosition;

    private float _maxDistance = 1200f;

    private void Update()
    {
        float distance = Vector2.Distance(_playerPosition.position, _spaceObjectPosition.position);

        if (distance > _maxDistance)
        {
            Debug.Log("SUKA");
        }
    }

    public void Init(ref Transform playerPosition, ref Transform spaceObjectPosition)
    {
        _playerPosition = playerPosition;
        _spaceObjectPosition = spaceObjectPosition;
    }
}

