using System;
using Source.Objects;
using System.Collections;
using Source;
using UnityEngine;
using Random = UnityEngine.Random;

public class WormHole : MonoBehaviour
{
    [SerializeField] private int _holeRank;
    private Vector2 _transform;
    private float _attractionTime = 3;
    private Bootstrap _bs;
    private void Awake()
    {
        _bs = Bootstrap.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(Attraction(player));

            if (G.CurrentLevel != G.FastTravelLVL)
            {
                KickOut(player);
                return;
            }

            _bs.ChangeGameScene(_holeRank);
        }
    }

    private void KickOut(Player player)
    {
        Vector2 kickOutPoint = new Vector2(transform.position.x + Random.Range(-20, 20), transform.position.x + Random.Range(-20, 20));
        player._rigidbody.AddForce(kickOutPoint * Source.G.AttractionForce, ForceMode2D.Impulse);

    }

    private IEnumerator Attraction(Player player)
    {
        yield return new WaitForSeconds(_attractionTime);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        player._rigidbody.AddForce((_transform - playerPos) * Source.G.AttractionForce, ForceMode2D.Force);
    }
}
