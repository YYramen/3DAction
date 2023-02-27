using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �L�����N�^�[�C���^�[�t�F�[�X
/// </summary>
interface ICharacter
{
    float EvaluatePlan(EnemyMovementBase plan);
    EnemyMovementBase Evaluate(List<EnemyMovementBase> plans);
}

public class EnemyCharacterBase<T> : ICharacter where T : EnemyAIBase
{
    protected T _owner;

    #region Constructor

    // �R���X�g���N�^
    public EnemyCharacterBase(T owner)
    {
        _owner = owner;
    }

    #endregion


    /// <summary>
    /// �v�������X�g��]�����āA��V�����݂���ԍ������̂�Ԃ�
    /// </summary>
    /// <param name="plans">�]���Ώۂ̃v�������X�g</param>
    /// <returns>�I�����ꂽ�v����</returns>
    public virtual EnemyMovementBase Evaluate(List<EnemyMovementBase> plans)
    {
        float maxValue = 0f;
        EnemyMovementBase selectedPlan = null;
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
    public virtual float EvaluatePlan(EnemyMovementBase plan)
    {
        return 0f;
    }
}
