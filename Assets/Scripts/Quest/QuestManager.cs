using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// クエスト全体を管理
public class QuestManager : MonoBehaviour
{
  public StageUIManager stageUI;
  public GameObject enemyPrefab;
  public BattleManager battleManager;
  public SceneTransitionManager sceneTransitionManager;
	public GameObject questBG;

  // 敵に遭遇するテーブル: -1なら遭遇しない、0なら遭遇
  int[] encountTable = { -1, -1, 0, -1, 0, -1 };

  int currentStage = 0; // 現在のステージ進行度

  private void Start()
  {
    stageUI.UpdateUI(currentStage);
  }

  // Nextボタンが押されたら
  public void OnNextButton()
  {
		// 背景を大きく
		questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f).OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));
		// フェードアウト
		SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
		questBGSpriteRenderer.DOFade(0, 2f);

		SoundManager.instance.PlaySE(0);
		currentStage++;
    // 進行度をUIに反映
    stageUI.UpdateUI(currentStage);
    if (encountTable.Length <= currentStage)
    {
      Debug.Log("クエストクリア");
      QuestClear();
      // クリア処理
    }
    else if (encountTable[currentStage] == 0)
    {
      EncountEnemy();
    }
  }

	public void OnBackButton()
	{
		SoundManager.instance.PlaySE(0);
	}

  void EncountEnemy()
  {
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
		SoundManager.instance.StopBGM();
		SoundManager.instance.PlaySE(2);
		// クエストクリア！と表示する
		// 街に戻るボタンのみ表示する
		stageUI.ShowClearText();
    // sceneTransitionManager.LoadTo("Town");
  }
}
