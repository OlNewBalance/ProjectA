using System;
using System.Collections.Generic;

namespace Source.StateMachine
{
    public class StateMachine
    {
        public readonly Dictionary<StateName, IState> States;
        private IState _currentState;
        private Bootstrap _bs;
        public StateMachine(Bootstrap bs, StateName initialState)
        {
            _bs = bs;
            States = new Dictionary<StateName, IState>()
            {
                { StateName.Menu , new  MenuState(bs) },
                { StateName.Game , new Game(bs) },
                {StateName.GameOver, new GameOver(bs)},
                {StateName.Victory, new Victory(bs)}
            };
            _currentState = States[initialState];
            _currentState.Enter();
        }

        public void SwitchState(StateName name)
        {
            if (States.ContainsKey(name))
            {
                _currentState.Exit();
                _currentState = States[name];
                _currentState.Enter();
                return;
            }

            throw new InsufficientStateException($"{name} is not in the statemachine");
        }
    }

    internal class InsufficientStateException : Exception
    {
        public InsufficientStateException(string message) : base(message) { }
    }

    

    public enum StateName
    {
        Menu,
        Game,
        GameOver,
        Loading,
        Win,
        Victory
    }
}