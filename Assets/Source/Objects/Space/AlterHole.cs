using Source.Objects;
using UnityEngine;

public class AlterHole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Suka1");
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("Suka2");
            KickOut(player);
            Debug.Log("Suka3");
        }    
    }

    private void KickOut(Player player)
    {
        Debug.Log("Suka4");
        Vector2 kickOutPoint = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
        Debug.Log("Suka5");
        player._rigidbody.AddForce(kickOutPoint * Source.G.AttractionForce, ForceMode2D.Impulse);
        Debug.Log("Suka6");
    }
}
