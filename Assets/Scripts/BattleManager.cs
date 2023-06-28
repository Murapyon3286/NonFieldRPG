using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player‚ÆEnemy‚Ì‘Îí‚ÌŠÇ—
public class BattleManager : MonoBehaviour
{
  public PlayerUIManager playerUI;
  public EnemyUIManager enemyUI;
  public PlayerManager player;
  public EnemyManager enemy;

  void Start()
  {
    // Player‚ªEnemy‚ÉUŒ‚
    player.Attack(enemy);
    enemyUI.UpdateUI(enemy);
    // Enemy‚ªPlayer‚ÉUŒ‚
    enemy.Attack(player);
    playerUI.UpdateUI(player);
  }
}
