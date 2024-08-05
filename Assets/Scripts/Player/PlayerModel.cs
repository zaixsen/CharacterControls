using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModelFoot
{
    Right, Left,
}
public class PlayerModel : MonoBehaviour, IHurt
{
    [HideInInspector] public Animator animator;

    [HideInInspector] public PlayerState currentState;

    [HideInInspector] public float gravity = -9.8f;

    [HideInInspector] public CharacterController characterController;
    /// <summary>
    /// ���������ļ�
    /// </summary>
    public SkillConfig skillConfig;

    //���п�ʼ��ͷ
    public GameObject bigSkillStartShot;

    public GameObject bigSkillShot;
    //�����б�
    public WeaponController[] weapons;

    AnimatorStateInfo animatorStateInfo;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    /// <summary>
    /// ��ʼ��������ײ
    /// </summary>
    /// <param name="enemyTagList"></param>
    public void Init(List<string> enemyTagList)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].Init(enemyTagList, OnHit);
        }
    }

    /// <summary>
    /// �����ص�
    /// </summary>
    /// <param name="enemy"></param>
    private void OnHit(IHurt enemy)
    {
        Debug.Log(((Component)enemy).name);
    }

    /// <summary>
    /// ��ʼ����˺�
    /// </summary>
    /// <param name="weaponIndex"></param>
    public void StartHit(int weaponIndex)
    {
        weapons[weaponIndex].StartHit();
    }

    /// <summary>
    /// ֹͣ����˺�
    /// </summary>
    /// <param name="weaponIndex"></param>
    public void StopHit(int weaponIndex)
    {
        weapons[weaponIndex].StopHit();
    }

    #region ����״̬
    [HideInInspector] public ModelFoot foot = ModelFoot.Right;
    /// <summary>
    /// ����ģ��
    /// </summary>
    public void Enter(Vector3 pos, Quaternion rot)
    {
        MonoManager.Instance.RemoveUpdateTask(OnExit);
        #region ���ý�ɫ����λ��
        //���ұ߳���
        Vector3 rightDirection = rot * Vector3.right;
        pos += rightDirection * .8f;

        //����󷴷�������
        Vector3 backDirection = rot * Vector3.back;
        pos += backDirection * 3f;

        characterController.Move(pos - transform.position);
        transform.rotation = rot;
        #endregion
    }

    /// <summary>
    /// �л�ģ��
    /// </summary>
    public void Exit()
    {
        PlayerController.Instance.PlayerAnimation("SwitchOut_Normal", .1f);
        MonoManager.Instance.AddUpdateTask(OnExit);
    }

    public void OnExit()
    {
        if (IsAnimationEnd())
        {
            gameObject.SetActive(false);
            MonoManager.Instance.RemoveUpdateTask(OnExit);
        }
    }

    public bool IsAnimationEnd()
    {
        //refresh animator state info 
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return animatorStateInfo.normalizedTime >= 1.0f && !animator.IsInTransition(0);
    }
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

    private void OnDisable()
    {
        skillConfig.currentNormalAttackIndex = 1;
    }
}
