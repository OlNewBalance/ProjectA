using UnityEngine;

namespace Source.Move
{
    public interface IMove
    {
       void MoveTo(Vector2 direction);
       void RotateTo(Vector2 direction);
       public void SetSpeed(float speed);
       public void SetMaxSpeed(float value);

    }
}
