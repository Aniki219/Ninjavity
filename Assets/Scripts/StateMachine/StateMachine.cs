using Unity.VisualScripting;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour {
    public enum PhaseEnum {
        START,
        UPDATE,
        EXIT
    }

    public PhaseEnum phase {get; private set;}

    public State initialState;
    private State activeState;
    private State nextState;

    void Start() {
        activeState = initialState;
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
        nextState = state;
        phase = PhaseEnum.EXIT;
    }
}