using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v�����i�[�̃C���^�[�t�F�[�X
/// </summary>
interface IPlanner
{
    float EvaluatePlan(EnemyPlanBase plan);
    EnemyPlanBase Evaluate(List<EnemyPlanBase> plans);
}

/// <summary>
/// �v�����i�[�̊��N���X
/// �v�������X�g����œK�ȃv������I������
/// </summary>
/// <typeparam name="T"></typeparam>
public class EnemyPlannerBase : IPlanner
{
    protected EnemyPlannerBase _owner;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public EnemyPlannerBase(EnemyPlannerBase owner)
    {
        _owner = owner;
    }

    /// <summary>
    /// �v�������X�g��]�����Ĉ�Ԃ������ʂł�����̂�Ԃ�
    /// </summary>
    /// <param name="plans">�]���Ώۂ̃v�������X�g</param>
    /// <returns>�I�����ꂽ�v����</returns>
    public virtual EnemyPlanBase Evaluate(List<EnemyPlanBase> plans)
    {
        float maxValue = 0f;
        EnemyPlanBase selectedPlan = null;
        foreach (var plan in plans)
        {
            float value = EvaluatePlan(plan);
            if (maxValue <= value)
            {
                maxValue = value;
                selectedPlan = plan;
            }
        }

        return selectedPlan;
    }

    /// <summary>
    /// �v������]������
    /// </summary>
    /// <param name="plan">�]���Ώۂ̃v����</param>
    /// <returns>�I�[�i�[�̌��݂̏�Ԃ����������v�����ɉ�������V�����ݒl</returns>
    public virtual float EvaluatePlan(EnemyPlanBase plan)
    {
        return 0f;
    }
}
