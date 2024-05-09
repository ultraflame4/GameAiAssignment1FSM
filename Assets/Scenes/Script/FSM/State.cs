using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class State
    {
        public string Name { get; protected set; }
        public FiniteStateMachine fsm { get; private set; }
        public State(FiniteStateMachine fsm)
        {
            this.fsm = fsm;
        }

        /// <summary>
        /// Called Immediately when state is entered
        /// </summary>
        protected virtual void OnEnter() { }
        /// <summary>
        /// Called at the start of a new frame after OnEnter()
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerator OnStart() { yield return 0; }
        protected virtual void OnExit() { }


        public void Enter()
        {
            OnEnter();
        }


        public IEnumerator Start()
        {
            return OnStart();
        }

        public void Exit()
        {
            OnExit();
        }

    }
}