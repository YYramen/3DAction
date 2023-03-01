using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������c�����Ă����L���I�u�W�F�N�g
/// </summary>
public class MovementMemory : MonoBehaviour
{
    public EnemyMovementBase Movement { get; set; }
    public Vector3 Position { get; set; }
    public GameObject Target { get; set; }


    #region Constructor

    public MovementMemory()
    {
        //
    }

    public MovementMemory(EnemyMovementBase movementObject)
    {
        Movement = movementObject.Plan;
        Target = movementObject.Target;
        Position = movementObject.Position;
    }

    #endregion
}
