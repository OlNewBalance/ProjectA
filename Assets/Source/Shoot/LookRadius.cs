using Source.Objects;
using UnityEngine;

public class LookRadius : MonoBehaviour
{
    private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _player = player;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out _))
        {
            _player = null;
        }
    }

    public ref readonly Player Player()
    {
        return ref _player;
    }
}