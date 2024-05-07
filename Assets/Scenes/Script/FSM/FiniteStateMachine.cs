using System;

namespace FSM
{
    public class FiniteStateMachine
    {

        public delegate void OnStateChanged(State prev, State next);
        public event OnStateChanged StateChanged;

        public State currentState { get; private set; }

        public void Transition(State nextState)
        {
            if (nextState == null) throw new NullReferenceException("Attempted to transition to null state!");
            if (currentState == null) throw new NullReferenceException("Current state is null!");

            StateChanged?.Invoke(currentState,nextState);

            currentState.Exit();
            currentState = nextState;
            currentState.Enter();
        }

        public void Execute()
        {
            if (currentState == null) throw new NullReferenceException("Current state is null!");
            currentState.Execute();
        }

    }
}