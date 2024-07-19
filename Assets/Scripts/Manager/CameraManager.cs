using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �������
/// </summary>
public class CameraManager : SingleMonoBase<CameraManager>
{
    /// <summary>
    /// �������
    /// </summary>
    public CinemachineBrain cm_brain;

    /// <summary>
    /// �������
    /// </summary>
    public GameObject freeeLookCamera;

    public CinemachineFreeLook freeLook;

    /// <summary>
    /// ���������λ�� ʹ֮��������
    /// </summary>
    public void ResetFreeLookCamera()
    {
        freeLook.m_YAxis.Value = .5f;
        freeLook.m_XAxis.Value = PlayerController.Instance.playerModel.transform.eulerAngles.y;
    }
}
