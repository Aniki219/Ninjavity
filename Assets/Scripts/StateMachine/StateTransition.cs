public abstract class StateTransition {
    public State state {get; protected set;}

    public void Attach(State _state) {
        state = _state;
    }
    
    public virtual void checkCondition() {
    }
}