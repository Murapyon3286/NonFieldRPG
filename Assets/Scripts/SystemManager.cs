using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �N�G�X�g�S�̂��Ǘ�
public class SystemManager : MonoBehaviour
{
  int currentStage = 0; // ���݂̃X�e�[�W�i�s�x

  // Next�{�^���������ꂽ��
  public void OnNextButton()
  {
    currentStage++;
    Debug.Log("�i�s�x����" + currentStage);
  }
}
