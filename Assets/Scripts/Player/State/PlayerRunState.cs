using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerIdleState
{
    private Camera mainCamera;

    public override void Enter()
    {
        base.Enter();

        mainCamera = Camera.main;

        playerController.PlayerAnimation("Run");
    }

    public override void Update()
    {
        base.Update();

        #region 检测攻击
        #endregion

        #region 检测待机
        if (playerController.inputMoveVec2 == Vector2.zero)
        {
            playerController.SwitchState(PlayerState.Idle);
        }
        #endregion

        #region 处理移动方向
        if (playerController.inputMoveVec2 != Vector2.zero)
        {
            Vector3 inputMoveVec3 = new Vector3(playerController.inputMoveVec2.x, 0, playerController.inputMoveVec2.y);

            //Get main camera eulerAngles y
            float cameraAxisY = mainCamera.transform.eulerAngles.y;

            //四元数 * 向量  数学公式  有时间研究一下
            Vector3 targetDir = Quaternion.Euler(0, cameraAxisY, 0) * inputMoveVec3;
            Quaternion targetQua = Quaternion.LookRotation(targetDir);
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, targetQua, Time.deltaTime * playerController.rotationSpeed);
        }
        #endregion  
    }

}
