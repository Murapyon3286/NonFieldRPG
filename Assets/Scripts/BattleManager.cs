using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player‚ÆEnemy‚Ì‘Îí‚ÌŠÇ—
public class BattleManager : MonoBehaviour
{
  public SystemManager systemManager;
  public PlayerUIManager playerUI;
  public EnemyUIManager enemyUI;
  public PlayerManager player;
  EnemyManager enemy;

  void Start()
  {
    enemyUI.gameObject.SetActive(false);
  }

  // ‰Šúİ’è
  public void Setup(EnemyManager enemyManager)
  {
    enemyUI.gameObject.SetActive(true);
    enemy = enemyManager;
    enemyUI.SetupUI(enemy);
    playerUI.SetupUI(player);

    enemy.addEventListenerOnTap(PlayerAttack);
  }

  void PlayerAttack()
  {
    player.Attack(enemy);
    enemyUI.UpdateUI(enemy);
    if (enemy.hp <= 0)
    {
      enemyUI.gameObject.SetActive(false);
      Destroy(enemy.gameObject);
      EndBattle();
    }
    else
    {
      EnemyTurn();
    }
  }

  void EnemyTurn()
  {
    enemy.Attack(player);
    playerUI.UpdateUI(player);
  }

  void EndBattle()
  {
    systemManager.EndBattle();
  }
}
