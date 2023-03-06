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


    #region �R���X�g���N�^

    public MovementMemory()
    {
        //
    }

    public MovementMemory(MovementObject movementObject)
    {
        Movement = movementObject.Movement;
        Target = movementObject.Target;
        Position = movementObject.Position;
    }

    #endregion
}
