using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プランナーのインターフェース
/// </summary>
interface IPlanner
{
    float EvaluatePlan(EnemyPlanBase plan);
    EnemyPlanBase Evaluate(List<EnemyPlanBase> plans);
}

/// <summary>
/// プランナーの基底クラス
/// プランリストから最適なプランを選択する
/// </summary>
/// <typeparam name="T"></typeparam>
public class EnemyPlannerBase : IPlanner
{
    protected EnemyPlannerBase _owner;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public EnemyPlannerBase(EnemyPlannerBase owner)
    {
        _owner = owner;
    }

    /// <summary>
    /// プランリストを評価して一番いい結果であるものを返す
    /// </summary>
    /// <param name="plans">評価対象のプランリスト</param>
    /// <returns>選択されたプラン</returns>
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
    /// プランを評価する
    /// </summary>
    /// <param name="plan">評価対象のプラン</param>
    /// <returns>オーナーの現在の状態を加味したプランに応じた報酬見込み値</returns>
    public virtual float EvaluatePlan(EnemyPlanBase plan)
    {
        return 0f;
    }
}
