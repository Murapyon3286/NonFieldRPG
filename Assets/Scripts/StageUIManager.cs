using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// StageUI（ステージ数・進行ボタン・バックボタン）
public class StageUIManager : MonoBehaviour
{
  public Text stageText;
  public GameObject nextButton;
  public GameObject backButton;

  public void UpdateUI(int currentStage)
  {
    stageText.text = string.Format("ステージ：{0}", currentStage + 1);
  }

  public void HideButtons()
  {
    nextButton.SetActive(false);
    backButton.SetActive(false);
  }

  public void ShowButtons()
  {
    nextButton.SetActive(true);
    backButton.SetActive(true);
  }
  /*
  上記のボタン表示・非表示を一つにまとめることも可能。
  public void ShowButtons(bool isTrue)
  {
    nextButton.SetActive(isTrue);
    backButton.SetActive(isTrue);
  }
  */
}
