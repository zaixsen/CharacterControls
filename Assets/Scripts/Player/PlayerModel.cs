using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModelFoot
{
    Right, Left,
}
public class PlayerModel : MonoBehaviour
{
    public Animator animator;

    [HideInInspector] public PlayerState state;

    [HideInInspector] public float gravity = -9.8f;

    public CharacterController characterController;
    /// <summary>
    /// ���������ļ�
    /// </summary>
    public SkillConfig skillConfig;

    //���п�ʼ��ͷ
    public GameObject bigSkillStartShot;

    public GameObject bigSkillShot;


    #region ����״̬
    [HideInInspector] public ModelFoot foot = ModelFoot.Right;
    /// <summary>
    /// Take left foot
    /// </summary>
    public void SetOutLeftFoot()
    {
        foot = ModelFoot.Left;
    }
    /// <summary>
    /// Take right foot
    /// </summary>
    public void SetOutRightFoot()
    {
        foot = ModelFoot.Right;
    }
    #endregion

}
