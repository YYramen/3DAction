using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̃v�����̊��N���X
/// </summary>
public class EnemyPlanBase
{
    /// <summary>
    /// �S�[���̃^�C�v(�v�����̎�ނɑ�������)
    /// </summary>
    public enum GoalType
    {
        Idle,
        Attack,
        Defence,
    }

    /// <summary>
    /// ����ړI�Ƃ��邩�̎��
    /// </summary>
    public enum RewardType
    {
        Health,
        Stamina,
    }
}
