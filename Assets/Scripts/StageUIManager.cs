using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// StageUI�i�X�e�[�W���E�i�s�{�^���E�o�b�N�{�^���j
public class StageUIManager : MonoBehaviour
{
  public Text stageText;
  public GameObject nextButton;
  public GameObject backButton;

  public void UpdateUI(int currentStage)
  {
    stageText.text = string.Format("�X�e�[�W�F{0}", currentStage + 1);
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
  ��L�̃{�^���\���E��\������ɂ܂Ƃ߂邱�Ƃ��\�B
  public void ShowButtons(bool isTrue)
  {
    nextButton.SetActive(isTrue);
    backButton.SetActive(isTrue);
  }
  */
}
