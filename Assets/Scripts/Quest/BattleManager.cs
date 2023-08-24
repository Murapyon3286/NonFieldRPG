using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// PlayerとEnemyの対戦の管理
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

    enemy.addEventListenerOnTap(PlayerAttack);
  }

  void PlayerAttack()
  {
		StopAllCoroutines();
		int damage = player.Attack(enemy);
		DialogTextManager.instance.SetScenarios(new string[] { $"プレイヤーの攻撃！\r\nモンスターに{damage}ダメージを与えた。" });
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
		DialogTextManager.instance.SetScenarios(new string[] { $"モンスターの攻撃\r\nプレイヤーは{damage}ダメージを受けた。" });
		SoundManager.instance.PlaySE(1);
		PlayerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
    playerUI.UpdateUI(player);
		if (player.hp <= 0)
		{
			yield return new WaitForSeconds(2f);
			DialogTextManager.instance.SetScenarios(new string[] { "力尽きてしまった。\r\n街に戻ろう。" });
			yield return new WaitForSeconds(2f);
			// playerが死んだ場合の実装
			questManager.PlayerDeath();
		}
  }

  IEnumerator EndBattle()
  {
		yield return new WaitForSeconds(2f);
		DialogTextManager.instance.SetScenarios(new string[] { "モンスターは逃げていった。" });
		enemyUI.gameObject.SetActive(false);
		Destroy(enemy.gameObject);
		// playerの攻撃力を上げる
		player.UpAttackPoint();
		playerUI.UpdateUI(player);
		SoundManager.instance.PlayBGM("Quest");
		questManager.EndBattle();
  }
}
