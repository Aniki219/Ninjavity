using States;
using UnityEngine;

public class OnAnimationEnd<T> : StateTransition where T : State {
    EntityStateMachine sm;

    protected override void AttachComponents() {
        sm = state.stateMachine as EntityStateMachine;
    }

    public override void checkCondition() {
        if (sm.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) {
            state.stateMachine.ChangeState<T>();
        }
    }
}