using System.Collections.Generic;

public abstract class State {
    public List<StateBehavior> behaviors;
    public List<StateTransition> transitions;

    public virtual void Start() {

    }

    public virtual void Update() {

    }

    public virtual void Exit() {

    }
}