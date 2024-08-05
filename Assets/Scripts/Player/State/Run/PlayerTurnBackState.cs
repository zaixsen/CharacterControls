using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 180 rad turn back
/// </summary>
public class PlayerTurnBackState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();
        playerController.PlayerAnimation("TurnBack", 0.1f);
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

        #region ºÏ≤‚∂Øª≠ «∑ÒΩ· ¯

        if (IsAnimationEnd())
        {
            playerController.SwitchState(PlayerState.Walk);
            return;
        }

        #endregion

    }

}
