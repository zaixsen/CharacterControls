using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��������
/// </summary>
[CreateAssetMenu(menuName = "Config/Skill")]
public class SkillConfig : ScriptableObject
{
    /// <summary>
    /// ��ǰ��ͨ���������Ķ���
    /// </summary>
    [HideInInspector] public int currentNormalAttackIndex = 1;
    /// <summary>
    /// ��ͨ����ÿ�ε��˺�����
    /// </summary>
    public float[] normalAttackDamageMultiple;

}
