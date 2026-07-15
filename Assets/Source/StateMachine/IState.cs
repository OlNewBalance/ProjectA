using UnityEngine;

namespace Source.StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}