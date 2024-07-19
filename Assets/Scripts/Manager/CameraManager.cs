using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 相机管理
/// </summary>
public class CameraManager : SingleMonoBase<CameraManager>
{
    /// <summary>
    /// 大脑组件
    /// </summary>
    public CinemachineBrain cm_brain;

    /// <summary>
    /// 自由相机
    /// </summary>
    public GameObject freeeLookCamera;

    public CinemachineFreeLook freeLook;

    /// <summary>
    /// 重置摄像机位置 使之看玩家身后
    /// </summary>
    public void ResetFreeLookCamera()
    {
        freeLook.m_YAxis.Value = .5f;
        freeLook.m_XAxis.Value = PlayerController.Instance.playerModel.transform.eulerAngles.y;
    }
}
