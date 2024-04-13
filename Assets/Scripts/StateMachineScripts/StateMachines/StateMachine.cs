using System;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour {
    public enum PhaseEnum {
        START,
        UPDATE,
        EXIT
    }

    public PhaseEnum phase {get; protected set;}

    public State initialState;
    protected State activeState;
    protected State nextState;

    protected virtual void Start() {
        activeState = initialState;
        activeState.Attach(this);
        phase = PhaseEnum.START;
    }

    protected virtual void Update() {
        switch(phase) {
            case PhaseEnum.START:
                OnStateStart();
                break;
            case PhaseEnum.UPDATE:
                OnStateUpdate();
                break;
            case PhaseEnum.EXIT:
                OnStateExit();
                break;
        }
    }

    public void ChangeState<T>() where T : State {
        nextState = (T) Activator.CreateInstance(typeof(T));
        nextState.Attach(this);
        Debug.Log((this as PlayerStateMachine).cc.collisionState.below);
        phase = PhaseEnum.EXIT;
    }

    protected virtual void OnStateStart() {
        activeState.behaviors.ForEach(b => b.Start());
        phase = PhaseEnum.UPDATE;
    }

    protected virtual void OnStateUpdate() {
        activeState.behaviors.ForEach(b => b.Update());
        activeState.transitions.ForEach(t => t.checkCondition());
    }

    protected virtual void OnStateExit() {
        activeState.behaviors.ForEach(b => b.Exit());
        activeState = nextState;
        phase = PhaseEnum.START; 
    }
}