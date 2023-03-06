using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 動きを把握しておく記憶オブジェクト
/// </summary>
public class MovementMemory : MonoBehaviour
{
    public EnemyMovementBase Movement { get; set; }
    public Vector3 Position { get; set; }
    public GameObject Target { get; set; }


    #region コンストラクタ

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
