using Source.Objects;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class AvailableArea : MonoBehaviour
{
    private Vector2 _playerPosition;
    private Vector2 _spaceObjectPosition;

    private float _maxDistance = 1200f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _playerPosition = player.PlayerPosition();
            _spaceObjectPosition = transform.position;
        }
    }

    private void Update()
    {
        float distance = Vector2.Distance(_playerPosition, _spaceObjectPosition);

        if (distance > _maxDistance)
        {
            Debug.Log("SUKA");
        }
    }
}

