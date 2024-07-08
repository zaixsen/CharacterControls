using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player controller
/// </summary>
public class PlayerController : MonoBehaviour, IStateMachineOwner
{
    public PlayerModel playerModel;

    private StateMachine stateMachine;

    public InputSystem inputActions;

    private Vector2 inputMoveVec2;

    private void Awake()
    {
        stateMachine = new StateMachine(this);
        inputActions = new InputSystem();
    }

    private void Start()
    {
        SwitchState(PlayerState.Run);
    }
    private void Update()
    {
        inputMoveVec2 = inputActions.Player.Move.ReadValue<Vector2>().normalized;
    }
    /// <summary>
    /// Switch state
    /// </summary>
    /// <param name="playerState">player state</param>
    public void SwitchState(PlayerState playerState)
    {
        switch (playerState)
        {
            case PlayerState.Idle:
                stateMachine.EnterState<PlayerIdleState>();
                break;
            case PlayerState.Run:
                stateMachine.EnterState<PlayerRunState>();
                break;
            default:
                break;
        }

        playerModel.state = playerState;
    }
    /// <summary>
    /// Play Animation
    /// </summary>
    /// <param name="animationName">Animation Name</param>
    /// <param name="fixedTransitionDuration">Duration</param>
    public void PlayerAnimation(string animationName, float fixedTransitionDuration = 0.25f)
    {
        playerModel.animator.CrossFadeInFixedTime(animationName, fixedTransitionDuration);
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
