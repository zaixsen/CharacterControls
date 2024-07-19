using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillBigStartState : PlayerStateBase
{

    public override void Enter()
    {
        base.Enter();
        //ÇÐ»»¾µÍ·
        CameraManager.Instance.cm_brain.m_DefaultBlend = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.Cut, 2f);
        CameraManager.Instance.freeeLookCamera.SetActive(false);
        playerModel.bigSkillStartShot.SetActive(true);

        playerController.PlayerAnimation("BigSkill_Start",0f);
    }

    public override void Update()
    {
        base.Update();


        #region ÅÐ¶Ï¶¯»­ÊÇ·ñ½áÊø

        if (IsAnimationEnd())
        {
            playerController.SwitchState(PlayerState.BigSkill);
            return;
        }

        #endregion
    }
}
