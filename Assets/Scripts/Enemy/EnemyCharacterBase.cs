using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクターインターフェース
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

    // コンストラクタ
    public EnemyCharacterBase(T owner)
    {
        _owner = owner;
    }

    #endregion


    /// <summary>
    /// プランリストを評価して、報酬見込みが一番高いものを返す
    /// </summary>
    /// <param name="plans">評価対象のプランリスト</param>
    /// <returns>選択されたプラン</returns>
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
    /// プランを評価する
    /// </summary>
    /// <param name="plan">評価対象のプラン</param>
    /// <returns>オーナーの現在の状態を加味したプランに応じた報酬見込み値</returns>
    public virtual float EvaluatePlan(EnemyMovementBase plan)
    {
        return 0f;
    }
}
