public class PlayerStateBehavior : StateBehavior {
    protected PlayerStateMachine pc;
    protected CharacterController2D cc;

    protected override void AttachComponents() {
        pc = state.stateMachine as PlayerStateMachine;
        cc = pc.cc;
    }
}