using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AIの基底クラス
///
/// 各種パラメータなど、UI判断に必要な情報を集約する。
/// 基本的に、クラスがゴールを実行し、
/// クラスがゴールをプランニングすることでAIを実現する。
/// </summary>
public class EnemyAIBase : MonoBehaviour
{
    
    private TaskCalculate<EnemyAIBase> _taskCalc;

    [SerializeField]
    private Transform[] _wanderTargets;
    public Transform[] WanderTargets { get { return _wanderTargets; } }

    // 現在の体力
    [SerializeField]
    [Range(0f, 1f)]
    private float _health = 0.5f;
    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            _health = value;
        }
    }

    // スタミナ
    [SerializeField]
    [Range(0f, 1f)]
    private float _energy = 0.5f;
    public float Energy
    {
        get
        {
            return _energy;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            _energy = value;
        }
    }

    /// <summary>
    /// 対象がプランオブジェクトを保持しているかを検証
    /// </summary>
    /// <param name="target">検証対象</param>
    /// <param name="movementObject">取得したプランオブジェクトの参照を返す</param>
    /// <returns>保持している場合はture</returns>
    protected virtual bool HasPlan(GameObject target, out MovementObject movementObject)
    {
        movementObject = target.GetComponent<MovementObject>();
        return movementObject != null;
    }

    /// <summary>
    /// プランオブジェクトを保持する（記憶する）
    /// </summary>
    /// <param name="movementObject"></param>
    void StorePlanObject(MovementObject movementObject)
    {
        _taskCalc.Memorize(movementObject);
    }
}
