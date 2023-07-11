using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// PlayerとEnemyの対戦の管理
public class BattleManager : MonoBehaviour
{
	public Transform PlayerDamagePanel;
  public QuestManager systemManager;
  public PlayerUIManager playerUI;
  public EnemyUIManager enemyUI;
  public PlayerManager player;
  EnemyManager enemy;

  void Start()
  {
    enemyUI.gameObject.SetActive(false);
		// StartCoroutine(SampleCol());
  }

	// サンプルコルーチン
	/*
	IEnumerator SampleCol()
	{
		Debug.Log("コルーチン開始");
		yield return new WaitForSeconds(2f);
		Debug.Log("2秒経過");
	}
	*/

  // 初期設定
  public void Setup(EnemyManager enemyManager)
  {
		SoundManager.instance.PlayBGM("Battle");
    enemyUI.gameObject.SetActive(true);
    enemy = enemyManager;
    enemyUI.SetupUI(enemy);
    playerUI.SetupUI(player);

    enemy.addEventListenerOnTap(PlayerAttack);
  }

  void PlayerAttack()
  {
		StopAllCoroutines();
		SoundManager.instance.PlaySE(1);
    player.Attack(enemy);
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
		yield return new WaitForSeconds(1f);
		SoundManager.instance.PlaySE(1);
		PlayerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
		enemy.Attack(player);
    playerUI.UpdateUI(player);
  }

  IEnumerator EndBattle()
  {
		yield return new WaitForSeconds(1f);
		enemyUI.gameObject.SetActive(false);
		Destroy(enemy.gameObject);
		SoundManager.instance.PlayBGM("Quest");
		systemManager.EndBattle();
  }
}
