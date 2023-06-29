using System;
using UnityEngine;

// 敵を管理するもの（ステータス・クリック検出）
public class EnemyManager : MonoBehaviour
{
  // 関数登録
  Action tapAction; // クリックされたときに実行したい関数（外部から設定したい）

  public new string name;
  public int hp;
  public int at;

  // 攻撃する
  public void Attack(PlayerManager player)
  {
    player.Damage(at);
  }

  // ダメージを受ける
  public void Damage(int damage)
  {
    hp -= damage;
    if (hp <= 0)
    {
      hp = 0;
    }
  }

  // tapActionに関数を登録する関数を作る
  public void addEventListenerOnTap(Action action)
  {
    tapAction += action;
  }

  public void OnTap()
  {
    Debug.Log("クリックされた");
    tapAction();
  }
}
