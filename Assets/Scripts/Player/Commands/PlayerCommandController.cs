using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのコマンドを実行するクラス。
/// </summary>
public class PlayerCommandController : MonoBehaviour
{
    public void DoublePunch()
    {
        Debug.Log("ダブルパンチ");
    }

    public void PunchKickCombo()
    {
        Debug.Log("パンチキックコンボ");
    }

    public void KickPunchCombo()
    {
        Debug.Log("キックパンチコンボ");
    }
}
