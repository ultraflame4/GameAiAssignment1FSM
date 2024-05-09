using System;
using System.Collections;
using UnityEngine;

namespace FSM
{
    public class FiniteStateMachine : MonoBehaviour
    {

        public delegate void OnStateChanged(State prev, State next);
        public event OnStateChanged StateChanged;

        [field: SerializeField]
        public State nextState { get; private set; }
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

        /// <summary>
        /// Transitions to another state. Note that calling this will immediately stop the current state
        /// </summary>
        /// <param name="nextState"></param>
        /// <exception cref="NullReferenceException"></exception>
        public void Transition(State nextState)
        {
            if (nextState == null) throw new NullReferenceException("Attempted to transition to null state!");

            
            var prev = currentState;
            if (currentStateCoroutine !=null) StopCoroutine(currentStateCoroutine);
            currentState?.Exit();
            currentState = nextState;
            currentState.Enter();
            StateChanged?.Invoke(prev, nextState);
            currentStateCoroutine = StartCoroutine(currentState.Start());
        }

    }
}