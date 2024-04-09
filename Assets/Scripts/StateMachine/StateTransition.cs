public abstract class StateTransition {
    public readonly State transitionState;
    
    public virtual bool checkCondition() {
        return false;
    }
}