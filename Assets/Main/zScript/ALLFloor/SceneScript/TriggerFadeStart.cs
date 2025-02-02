﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*追加*/
using static ClearTime;
using static ClearTimeText;

public class TriggerFadeStart : MonoBehaviour
{
    [Header("スクリプト類")]
    [Tooltip("フェードをスタートする為の判定呼び出し用")]
    [SerializeField] private FadeOut FadeStart;//フェードアウト開始Bool判定呼び出し用
    [Tooltip("プレイヤーの動き制限する為の判定呼び出し用")]
    [SerializeField] private PlayerController operation;//プレイヤーの動き制限用
    
    [Header("判定類")]
    [Tooltip("シーンの移動が可能かどうか（階層をクリアしたかどうか）")]
    public bool CanNextScene = true;//シーン遷移が可能か不可能か
    [Tooltip("クリアタイムが必要かどうか（シーンに実装しているかしていないか）")]
    [SerializeField] private bool NeedTimeCount;//クリアタイムが実装していた場合の判定用

    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)//プレイヤーが当たったら
    {
        if (CanNextScene == true)//次の階層に移動可能なら
        {
            if (other.tag == "Player")
            {
                FadeStart.fadeStart = true;//次シーンへのフェードアウト開始
                operation.PlayerOperation = false;//プレイヤーの動きを止める

                if (NeedTimeCount == true)//クリアタイムが実装しているシーンなら
                {
                    ClearTimeText.ClearTImeFainal = ClearTimeText.ClearTImeFainal+ ClearTime.Lasttime;//クリアタイムを保存
                    ClearTime.CountStartEndFlag = false;//カウントを止める
                }
            }
        }
    }
}
