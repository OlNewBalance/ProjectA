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
        Vector2 kickOutPoint = new Vector2(transform.position.x + Random.Range(-20, 20), transform.position.x + Random.Range(-20, 20));
        player._rigidbody.AddForce(kickOutPoint * Source.G.AttractionForce, ForceMode2D.Impulse);
    }
}
