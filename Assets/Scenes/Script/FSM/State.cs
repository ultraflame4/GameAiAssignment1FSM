using System.Collections.Generic;

namespace FSM
{
    public class State
    {

        public string Name {get; protected set;}
        public FiniteStateMachine fsm { get; private set; }

        /// <summary>
        ///  Return state to transition to new state, return null to stay
        /// </summary>
        /// <returns>State, to transition to that state. Null to not transition</returns>
        public delegate State CheckTransitionCallback();
        public List<CheckTransitionCallback> Transitions;

        public State(FiniteStateMachine fsm)
        {
            this.fsm = fsm;
        }

        protected virtual void OnEnter() { }
        protected virtual void OnExecute() { }
        protected virtual void OnExit() { }


        public void Enter()
        {
            OnEnter();
        }

        public void Execute()
        {
            foreach (var callback in Transitions)
            {
                var next = callback?.Invoke();
                if (next != null)
                {
                    fsm.Transition(next);
                    return;
                }
            }

            OnExecute();

        }

        public void Exit()
        {
            OnExit();
        }

    }
}