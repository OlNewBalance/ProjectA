using Source.Objects;
using System.Collections;
using Unity.VectorGraphics;
using UnityEditor.Build.Content;
using UnityEditor.Build.Profile;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlterHole : MonoBehaviour
{
    private Vector2 _transform;
    private float _attractionTime = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Attraction(player);

            KickOut(player);
        }    
    }

    private void KickOut(Player player)
    {
        Vector2 kickOutPoint = new Vector2(transform.position.x + Random.Range(-20, 20), transform.position.x + Random.Range(-20, 20));
        player._rigidbody.AddForce(kickOutPoint * Source.G.AttractionForce, ForceMode2D.Impulse);
    }

    private IEnumerator Attraction(Player player)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        player._rigidbody.AddForce((_transform - playerPos) * Source.G.AttractionForce, ForceMode2D.Force);
        yield return new WaitForSeconds(_attractionTime);
    }
}
