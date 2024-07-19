using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player Evade End State 
/// </summary>
public class PlayerEvadeEndState : PlayerStateBase
{

    public override void Enter()
    {
        base.Enter();

        #region ≈–∂œ«∞∫Û…¡±‹

        switch (playerModel.state)
        {
            case PlayerState.Evade_Front:
                playerController.PlayerAnimation("Evade_Front_End");
                break;
            case PlayerState.Evade_Back:
                playerController.PlayerAnimation("Evade_Back_End");
                break;
        }
        #endregion

    }

    public override void Update()
    {
        base.Update();

        #region ºÏ≤‚¥Û’–
        if (playerController.inputActions.Player.BigSkill.triggered)
        {
            playerController.SwitchState(PlayerState.BigSkillStart);
            return;
        }
        #endregion

        #region “∆∂ØºÏ≤‚
        if (playerController.inputMoveVec2 != Vector2.zero)
        {
            playerController.SwitchState(PlayerState.Run);
            return;
        }
        #endregion

        #region ≈–∂œ∂Øª≠ «∑ÒΩ· ¯
        if (IsAnimationEnd())
        {
            playerController.SwitchState(PlayerState.Idle);
            return;
        }
        #endregion
    }

}
