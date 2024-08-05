using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();
        switch (playerModel.currentState)
        {
            case PlayerState.Idle_AFK:
                playerController.PlayerAnimation("Idle_AFK");
                break;
            case PlayerState.Idle:
                playerController.PlayerAnimation("Idle");
                break;
        }
    }

    public override void Update()
    {
        base.Update();

        #region ¼ì²â´óÕÐ
        if (playerController.inputActions.Player.BigSkill.triggered)
        {
            playerController.SwitchState(PlayerState.BigSkillStart);
            return;
        }
        #endregion

        #region ¼ì²â¹¥»÷

        if (playerController.inputActions.Player.Fire.triggered)
        {
            playerController.SwitchState(PlayerState.NormalAttack);
            return;
        }

        #endregion


        #region ¼àÌý±¼ÅÜ
        if (playerController.inputMoveVec2 != Vector2.zero)
        {
            playerController.SwitchState(PlayerState.Walk);
            return;
        }
        #endregion


        #region ¼ì²âÉÁ±Ü

        if (playerController.inputActions.Player.Evade.triggered)
        {
            playerController.SwitchState(PlayerState.Evade_Back);
            return;
        }

        #endregion

        #region ¼ì²â¹Ò»ú
        switch (playerModel.currentState)
        {
            case PlayerState.Idle:
                if (statePlayingTime > 3)
                {
                    playerController.SwitchState(PlayerState.Idle_AFK);
                }
                break;
            case PlayerState.Idle_AFK:
                if (IsAnimationEnd())
                {
                    playerController.SwitchState(PlayerState.Idle);
                }
                break;

        }

        #endregion
    }
}
