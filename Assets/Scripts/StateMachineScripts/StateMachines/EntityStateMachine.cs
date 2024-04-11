using UnityEngine;

public abstract class EntityStateMachine : StateMachine {
    [HideInInspector]
    public CharacterController2D cc;
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public SpriteRenderer sprite;
    
    private void Awake() {
        cc = GetComponent<CharacterController2D>();
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void OnStartPhase() {
        anim.Play(activeState.GetType().Name);
    }
}