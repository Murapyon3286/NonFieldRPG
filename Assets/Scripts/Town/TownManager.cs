using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
  // スタートボタンが押されたら
	public void OnQuestButton()
	{
		SoundManager.instance.PlaySE(0);
	}
}
