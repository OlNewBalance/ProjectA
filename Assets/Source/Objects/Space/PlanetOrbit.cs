using Source.Objects;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlanetOrbit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            KickOut(player);
        }
    }

    private void KickOut(Player player)
    {
        Vector2 kickOutPoint = new Vector2(player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y).normalized;
        player._rigidbody.AddForce(kickOutPoint * Source.G.AttractionForce, ForceMode2D.Impulse);
    }
}
