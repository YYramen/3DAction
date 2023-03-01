using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵AIが記憶できるオブジェクト
/// </summary>
public class MovementObject : MonoBehaviour
{
    public EnemyMovementBase Movement { get; private set; }
    public Vector3 Position { get { return transform.position; } }
    public GameObject Target { get { return gameObject; } }

    [SerializeField]
    private GoalType _goalType;

    void Awake()
    {
        switch (_goalType)
        {
            case GoalType.Wander:
                Movement = new PlanWander();
                break;

            case GoalType.Defence:
                Movement = new PlanGetPower();
                break;

            case GoalType.Attack:
                Movement = new PlanAttackTarget();
                break;

            default:
                break;
        }
    }
}
