using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
	private void Start()
	{
		DialogTextManager.instance.SetScenarios(new string[] { "�X�ɒ������B" });
	}

	// �X�^�[�g�{�^���������ꂽ��
	public void OnQuestButton()
	{
		SoundManager.instance.PlaySE(0);
	}

	public void OnSaveButton()
	{
		PlayerManager.GetInstance().Save();
		SoundManager.instance.PlaySE(0);
	}

	public void OnTitleButton()
	{
		SoundManager.instance.PlaySE(0);
	}
}
