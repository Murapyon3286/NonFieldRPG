using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
  // �X�^�[�g�{�^���������ꂽ��
	public void OnNewGameButton()
	{
		PlayerManager.GetInstance().DeleteSaveData();
		SoundManager.instance.PlaySE(0);
	}

	public void OnContinueButton()
	{
		PlayerManager.GetInstance().Load();
		SoundManager.instance.PlaySE(0);
	}
}
