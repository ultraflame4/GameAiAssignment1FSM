using System;
using UnityEngine;

namespace FSM
{
    public class FiniteStateMachine : MonoBehaviour
    {

        public delegate void OnStateChanged(State prev, State next);
        public event OnStateChanged StateChanged;

        public State currentState { get; private set; }
        public Coroutine currentStateCoroutine { get; private set; }

        
        public void SetInitialState(State initialState)
        {
            if (initialState == null) throw new NullReferenceException("The initial state cannot be null!");
            if (currentState == null)
            {
                Transition(initialState);
            }
        }

        public void Transition(State nextState)
        {
            if (nextState == null) throw new NullReferenceException("Attempted to transition to null state!");

            StateChanged?.Invoke(currentState, nextState);

            if (currentStateCoroutine !=null) StopCoroutine(currentStateCoroutine);
            currentState?.Exit();
            currentState = nextState;
            currentState.Enter();
            currentStateCoroutine = StartCoroutine(currentState.Start());
        }

    }
}