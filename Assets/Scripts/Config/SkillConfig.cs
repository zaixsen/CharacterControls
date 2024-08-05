using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 技能配置
/// </summary>
[CreateAssetMenu(menuName = "Config/Skill")]
public class SkillConfig : ScriptableObject
{
    /// <summary>
    /// 当前普通攻击所处的段数
    /// </summary>
    [HideInInspector] public int currentNormalAttackIndex = 1;
    /// <summary>
    /// 普通攻击每段的伤害倍率
    /// </summary>
    public float[] normalAttackDamageMultiple;

}
