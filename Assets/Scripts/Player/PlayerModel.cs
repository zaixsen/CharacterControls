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
    /// 技能配置文件
    /// </summary>
    public SkillConfig skillConfig;

    //大招开始镜头
    public GameObject bigSkillStartShot;

    public GameObject bigSkillShot;


    #region 动画状态
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
