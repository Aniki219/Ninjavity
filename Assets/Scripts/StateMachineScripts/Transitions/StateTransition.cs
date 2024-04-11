public abstract class StateTransition {
    public State state {get; protected set;}

    public void Attach(State _state) {
        state = _state;
        AttachComponents();
    }

    protected virtual void AttachComponents() {}
    
    public virtual void checkCondition() {
    }
}