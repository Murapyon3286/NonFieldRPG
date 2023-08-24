using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// Player��Enemy�̑ΐ�̊Ǘ�
public class BattleManager : MonoBehaviour
{
	public Transform PlayerDamagePanel;
  public QuestManager questManager;
  public PlayerUIManager playerUI;
  public EnemyUIManager enemyUI;
  public PlayerManager player;
  EnemyManager enemy;

  void Start()
  {
    enemyUI.gameObject.SetActive(false);
		// StartCoroutine(SampleCol());
		playerUI.SetupUI(player);
	}

	// �T���v���R���[�`��
	/*
	IEnumerator SampleCol()
	{
		Debug.Log("�R���[�`���J�n");
		yield return new WaitForSeconds(2f);
		Debug.Log("2�b�o��");
	}
	*/

  // �����ݒ�
  public void Setup(EnemyManager enemyManager)
  {
		SoundManager.instance.PlayBGM("Battle");
    enemyUI.gameObject.SetActive(true);
    enemy = enemyManager;
    enemyUI.SetupUI(enemy);

    enemy.addEventListenerOnTap(PlayerAttack);
  }

  void PlayerAttack()
  {
		StopAllCoroutines();
		int damage = player.Attack(enemy);
		DialogTextManager.instance.SetScenarios(new string[] { $"�v���C���[�̍U���I\r\n�����X�^�[��{damage}�_���[�W��^�����B" });
		SoundManager.instance.PlaySE(1);
    enemyUI.UpdateUI(enemy);
    if (enemy.hp <= 0)
    {
      StartCoroutine(EndBattle());
		}
    else
    {
      StartCoroutine(EnemyTurn());
    }
  }

  IEnumerator EnemyTurn()
  {
		yield return new WaitForSeconds(2f);
		int damage = enemy.Attack(player);
		DialogTextManager.instance.SetScenarios(new string[] { $"�����X�^�[�̍U��\r\n�v���C���[��{damage}�_���[�W���󂯂��B" });
		SoundManager.instance.PlaySE(1);
		PlayerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
    playerUI.UpdateUI(player);
		if (player.hp <= 0)
		{
			yield return new WaitForSeconds(2f);
			DialogTextManager.instance.SetScenarios(new string[] { "�͐s���Ă��܂����B\r\n�X�ɖ߂낤�B" });
			yield return new WaitForSeconds(2f);
			// player�����񂾏ꍇ�̎���
			questManager.PlayerDeath();
		}
  }

  IEnumerator EndBattle()
  {
		yield return new WaitForSeconds(2f);
		DialogTextManager.instance.SetScenarios(new string[] { "�����X�^�[�͓����Ă������B" });
		enemyUI.gameObject.SetActive(false);
		Destroy(enemy.gameObject);
		// player�̍U���͂��グ��
		player.UpAttackPoint();
		playerUI.UpdateUI(player);
		SoundManager.instance.PlayBGM("Quest");
		questManager.EndBattle();
  }
}
