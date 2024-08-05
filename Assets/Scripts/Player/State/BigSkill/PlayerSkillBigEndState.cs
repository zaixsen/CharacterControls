using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillBigEndState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();

        playerModel.bigSkillShot.SetActive(false);
        CameraManager.Instance.cm_brain.m_DefaultBlend = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.EaseInOut, 1f);
        CameraManager.Instance.freeeLookCamera.SetActive(true);
        CameraManager.Instance.ResetFreeLookCamera();

        playerController.PlayerAnimation("BigSkill_End", 0f);
    }

    public override void Update()
    {
        base.Update();

        #region ÅÐ¶Ï¶¯»­ÊÇ·ñ½áÊø

        if (IsAnimationEnd())
        {
            playerController.SwitchState(PlayerState.Idle);
            return;
        }

        #endregion
    }
}
