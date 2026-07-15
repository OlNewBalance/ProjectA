using Source;
using Source.CameraUtil;
using Source.Objects;
using System.Collections;
using UnityEngine;

public class WormHole : MonoBehaviour
{
    //[SerializeField] private FollowPlayer _followPlayer;
    [SerializeField] private SceneChanger _machine;
    [SerializeField] private int _holeRank;
    private Vector2 _transform;
    private float _attractionTime = 3;

    private void Awake()
    {
        _transform = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(Attraction(player));

            if (Source.G.CurrentLevel != Source.G.FastTravelLVL)
            {
                KickOut(player);
                return;
            }

            _machine.ChangeScene(_holeRank);
            //_machine.SetScene(_holeRank);
            //, player, _followPlayer
            //player.transform.position = Source.G.GloryHoles[_holeRank - 1].transform.position; //Õ¿œŒÃ»Õ¿À ¿ œŒÀ≈«ÕŒ...
        }
    }

    private void KickOut(Player player)
    {
        Vector2 kickOutPoint = new Vector2(transform.position.x + Random.Range(-20, 20), transform.position.x + Random.Range(-20, 20));
        player._rigidbody.AddForce(kickOutPoint * Source.G.AttractionForce, ForceMode2D.Impulse);

        // ÀŒ√» ¿ ≈—À» Õ≈ ’¬¿“¿≈“ À≈¬≈À¿
    }

    private IEnumerator Attraction(Player player)
    {
        yield return new WaitForSeconds(_attractionTime);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        player._rigidbody.AddForce((_transform - playerPos) * Source.G.AttractionForce, ForceMode2D.Force);
    }
}
