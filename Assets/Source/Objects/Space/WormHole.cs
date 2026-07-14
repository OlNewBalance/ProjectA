using Source.Objects;
using System.Collections;
using UnityEngine;

public class WormHole : MonoBehaviour
{
    [SerializeField] private int _holeRank;
    private Vector2 _transform;
    private float _attractionTime = 1;

    private void Awake()
    {
        _transform = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Suka7");
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("Suka8");
            StartCoroutine(Attraction(player));
            Debug.Log("Suka9");
            if (Source.G.CurrentLevel != Source.G.FastTravelLVL)
            {
                Debug.Log("Suka10");
                KickOut(player);
                Debug.Log("Suka13");
                return;
            }
            Debug.Log("Suka14");
            player.transform.position = Source.G.GloryHoles[_holeRank - 1].transform.position; //Õ¿œŒÃ»Õ¿À ¿ œŒÀ≈«ÕŒ...
            Debug.Log("Suka15");
        }
    }

    private void KickOut(Player player)
    {
        Debug.Log("Suka11");
        Vector2 kickOutPoint = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
        player._rigidbody.AddForce(kickOutPoint * Source.G.AttractionForce, ForceMode2D.Impulse);
        Debug.Log("Suka12");
        // ÀŒ√» ¿ ≈—À» Õ≈ ’¬¿“¿≈“ À≈¬≈À¿
    }

    private IEnumerator Attraction(Player player)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        player._rigidbody.AddForce((_transform - playerPos) * Source.G.AttractionForce, ForceMode2D.Force);
        yield return new WaitForSeconds(_attractionTime);
    }
}
