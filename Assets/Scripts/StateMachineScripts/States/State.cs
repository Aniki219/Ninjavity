using System.Collections.Generic;
using UnityEngine;

public abstract class State {
    public StateMachine stateMachine {get; private set;}
    public List<StateBehavior> behaviors {get; protected set;}
    public List<StateTransition> transitions {get; protected set;}

    public State() {
        behaviors = new List<StateBehavior>();
        transitions = new List<StateTransition>();
    }

    public virtual void Attach(StateMachine _stateMachine) {
        stateMachine = _stateMachine;
        behaviors.ForEach(b => b.Attach(this));
        transitions.ForEach(b => b.Attach(this));
    }
}