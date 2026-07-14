using UnityEngine;

namespace Source.Pickup
{
    [RequireComponent(typeof(Collider2D))]
    public class Picker: MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IPickup>(out var pickup))
            {
                pickup.OnPickup();
            }
        }
    }
}