public abstract class StateBehavior {
    public State state;

    public void Attach(State _state) {
        state = _state;
        AttachComponents();
    }

    protected virtual void AttachComponents() {

    }

    public virtual void Start() {

    }
    public virtual void Update() {

    }
    public virtual void Exit() {

    }
}