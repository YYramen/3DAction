using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPersonality : EnemyCharacterBase<EnemyAIBase>
{
    #region コンストラクタ

    // コンストラクタ
    public EnemyPersonality(EnemyAIBase owner) : base(owner) { }

    #endregion


    /// <summary>
    /// プランを評価する
    /// 方針は、できるだけエネルギーを蓄えつつ、パワーを拡充していく性格。
    /// つまりエネルギーの補充に充填を置く挙動にする。
    /// </summary>
    public override float EvaluatePlan(EnemyMovementBase plan)
    {
        float value = 0f;

        // 攻撃プランの場合は、オーナーの状態を見て攻撃に転じるかを判断する
        if (plan.MovementType == MovementType.Attack)
        {
            // パワーがない場合は攻撃できない
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
