using System.Collections.Generic;

namespace FSM
{
    public class State
    {

        public string Name {get; protected set;}
        public FiniteStateMachine fsm { get; private set; }
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
            OnExecute();
        }

        public void Exit()
        {
            OnExit();
        }

    }
}