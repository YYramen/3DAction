using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPersonality : EnemyCharacterBase<EnemyAIBase>
{
    #region �R���X�g���N�^

    // �R���X�g���N�^
    public EnemyPersonality(EnemyAIBase owner) : base(owner) { }

    #endregion


    /// <summary>
    /// �v������]������
    /// ���j�́A�ł��邾���G�l���M�[��~���A�p���[���g�[���Ă������i�B
    /// �܂�G�l���M�[�̕�[�ɏ[�U��u�������ɂ���B
    /// </summary>
    public override float EvaluatePlan(EnemyMovementBase plan)
    {
        float value = 0f;

        // �U���v�����̏ꍇ�́A�I�[�i�[�̏�Ԃ����čU���ɓ]���邩�𔻒f����
        if (plan.MovementType == MovementType.Attack)
        {
            // �p���[���Ȃ��ꍇ�͍U���ł��Ȃ�
            if (_owner.Health == 0.0f)
            {
                return 0f;
            }

            value += Mathf.Pow(_owner.Energy, 2f);
            value += Mathf.Pow(_owner.Health, 1.5f);
            return value;
        }

        foreach (var reward in plan.RewardProspects)
        {
            switch (reward.RewardType)
            {
                case RewardType.Enegy:
                    value += Mathf.Pow(1f - _owner.Energy, 2f) * reward.Value;
                    break;

                case RewardType.Power:
                    value += Mathf.Pow(1f - _owner.Health, 3f) * reward.Value;
                    break;
            }
        }

        return value;
    }
}