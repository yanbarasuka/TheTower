﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*追加*/
using DG.Tweening;


public class FadeOut : MonoBehaviour
{
    [Header("スクリプト類")]
    [SerializeField]
    private NextSceneManagement nextSceneManager;//シーンマネジメント（フェード後にシーン切り替えをする為）
    
    private CanvasGroup canvasGroup;//キャンバスグループ

    [HideInInspector] public bool fadeStart = false;//フェードスタート用のOn/Off
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 0);//キャンバスグループの初期値
    }
    // Update is called once per frame
    void Update()
    {
        if (fadeStart == true)//フェードスタートがTrueでフェードアウト開始
        {
            fadeOut();
            fadeStart = false;
        }
    }
    void fadeOut()
    {
        canvasGroup.DOFade(1, 3f).OnComplete(nextSceneManager.NextScene);//3秒かけてフェードアウトした後、次シーンへ切り替え
    }

   
    /*タイトルなどのボタンでフェードアウトする用のメソッド*/
    public void ButtonOnClick()
    {
        fadeStart = true;
    }
}
