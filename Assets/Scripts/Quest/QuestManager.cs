using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// �N�G�X�g�S�̂��Ǘ�
public class QuestManager : MonoBehaviour
{
  public StageUIManager stageUI;
  public GameObject enemyPrefab;
  public BattleManager battleManager;
  public SceneTransitionManager sceneTransitionManager;
	public GameObject questBG;

  // �G�ɑ�������e�[�u��: -1�Ȃ瑘�����Ȃ��A0�Ȃ瑘��
  int[] encountTable = { -1, -1, 0, -1, 0, -1 };

  int currentStage = 0; // ���݂̃X�e�[�W�i�s�x

  private void Start()
  {
    stageUI.UpdateUI(currentStage);
		DialogTextManager.instance.SetScenarios(new string[] { "�X�ɒ������B" });
  }

	IEnumerator Searching()
	{
		DialogTextManager.instance.SetScenarios(new string[] { "�T����..." });
		// �w�i��傫��
		questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f).OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));
		// �t�F�[�h�A�E�g
		SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
		questBGSpriteRenderer.DOFade(0, 2f).OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));
		// 2�b�ԏ�����ҋ@����
		yield return new WaitForSeconds(2f);

		currentStage++;
		// �i�s�x��UI�ɔ��f
		stageUI.UpdateUI(currentStage);
		if (encountTable.Length <= currentStage)
		{
			Debug.Log("�N�G�X�g�N���A");
			QuestClear();
			// �N���A����
		}
		else if (encountTable[currentStage] == 0)
		{
			EncountEnemy();
		}
		else
		{
			stageUI.ShowButtons();
		}
	}

  // Next�{�^���������ꂽ��
  public void OnNextButton()
  {
		SoundManager.instance.PlaySE(0);
		stageUI.HideButtons();
		StartCoroutine(Searching());
	}

	public void OnBackButton()
	{
		SoundManager.instance.PlaySE(0);
	}

  void EncountEnemy()
  {
		DialogTextManager.instance.SetScenarios(new string[] { "�����X�^�[�ɑ��������I" });
		stageUI.HideButtons();
    GameObject enemyObj= Instantiate(enemyPrefab);
    EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
    battleManager.Setup(enemy);
  }

  public void EndBattle()
  {
    stageUI.ShowButtons();
  }

  void QuestClear()
  {
		DialogTextManager.instance.SetScenarios(new string[] { "�󔠂���肵���B\n�X�ɖ߂낤�B" });
		SoundManager.instance.StopBGM();
		SoundManager.instance.PlaySE(2);
		// �N�G�X�g�N���A�I�ƕ\������
		// �X�ɖ߂�{�^���̂ݕ\������
		stageUI.ShowClearText();
    // sceneTransitionManager.LoadTo("Town");
  }

	public void PlayerDeath()
	{
		sceneTransitionManager.LoadTo("Town");
	}
}
