using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// クエスト全体を管理
public class SystemManager : MonoBehaviour
{
  int currentStage = 0; // 現在のステージ進行度

  // Nextボタンが押されたら
  public void OnNextButton()
  {
    currentStage++;
    Debug.Log("進行度増加" + currentStage);
  }
}
