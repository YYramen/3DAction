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
    private MovementType _goalType;

    void Awake()
    {
        switch (_goalType)
        {
            case MovementType.Wander:
                Movement = new WanderMovement();
                break;

            case MovementType.Defence:
                Movement = new AttackMovement();
                break;

            case MovementType.Attack:
                Movement = new PlanAttackTarget();
                break;

            default:
                break;
        }
    }
}
