using System;
using Unity.VisualScripting;
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
        ChangeState(initialState);
        activeState = nextState;
        phase = PhaseEnum.START;
    }

    void Update() {
        if (phase.Equals(PhaseEnum.UPDATE)) {
            activeState.transitions.ForEach(t => {
                if (t.checkCondition()) {
                    ChangeState(t.transitionState);
                    return;
                }
            });
            activeState.behaviors.ForEach(b => b.Update());
        }
        if (phase.Equals(PhaseEnum.START)) {
            Debug.Log(activeState);
            activeState.behaviors.ForEach(b => b.Start());
            phase = PhaseEnum.UPDATE;
        }   
        if (phase.Equals(PhaseEnum.EXIT)) {
            activeState.behaviors.ForEach(b => b.Exit());
            activeState = nextState;
            phase = PhaseEnum.START;
        }
    }

    public void ChangeState(State state) {
        Debug.Log("Change state to " + state.GetType().Name);
        nextState = state;
        nextState.Attach(this);
        phase = PhaseEnum.EXIT;
    }
}