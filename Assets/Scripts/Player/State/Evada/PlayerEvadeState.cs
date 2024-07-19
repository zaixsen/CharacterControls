using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
/// <summary>
/// Evade state …¡±‹◊¥Ã¨
/// </summary>
public class PlayerEvadeState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();
        #region ≈–∂œ«∞∫Û…¡±‹
        //Debug.Log(playerModel.state);

        switch (playerModel.state)
        {
            case PlayerState.Run:
                playerController.PlayerAnimation("Evade_Front");
                //Debug.Log("≤•∑≈∂Øª≠");
                break;
            case PlayerState.Idle:
            case PlayerState.RunEnd:
            case PlayerState.NormalAttackEnd:
                playerController.PlayerAnimation("Evade_Back");
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

        #region ≈–∂œ∂Øª≠ «∑ÒΩ· ¯

        if (IsAnimationEnd())
        {
            playerController.SwitchState(PlayerState.EvadeEnd);
            return;
        }

        #endregion

    }
}
