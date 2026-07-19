using System.Collections;
using System.Collections.Generic;
using Source;
using Source.Objects;
using Source.Objects.Space;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class AvailableArea : MonoBehaviour
{
    [SerializeField] private OutOfAreaPlaceholder outOfAreaPrefab;
    
    private CircleCollider2D _circleCollider;
    private Coroutine _dieCoroutine;
    private OutOfAreaPlaceholder _outOfAreaPlaceholder;
    
    private void OnEnable()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        
        _circleCollider.isTrigger = true;
        _circleCollider.radius = Main.Instance.AvailableRadius;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player _))
        {
            _dieCoroutine = StartCoroutine(StartGameOverScreen(5f));
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player _))
        {
            if (_dieCoroutine != null)
            {
                StopCoroutine(_dieCoroutine);
            }

            if (_outOfAreaPlaceholder)
            {
                _outOfAreaPlaceholder.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator StartGameOverScreen(float time)
    {
        if (!_outOfAreaPlaceholder)
        {
            _outOfAreaPlaceholder = Instantiate(outOfAreaPrefab, transform);
        }
        else
        {
            _outOfAreaPlaceholder.gameObject.SetActive(true);
        }
        for (var i = 0; i < time; i++)
        {
            _outOfAreaPlaceholder.SetEstimated(time - i);
            yield return new WaitForSeconds(1f);
        } 
        Main.Instance.Die();
        yield return null;
    }
}

