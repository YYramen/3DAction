using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̍s���p�^�[��
/// </summary>
public enum EnemyBehaviorType
{
    Idle,
    Defence,
    Attack,
}

/// <summary>
/// �G�̋���
/// </summary>
public enum EnemyLevel
{
    Easy = 1,
    Normal = 2,
    Hard = 3
}

public class EnemyBehaviors : MonoBehaviour
{
    [Tooltip("���݂�BehaviorType")] EnemyBehaviorType _currentType;

    public void SwitchType(EnemyBehaviorType type)
    {

    }
}
