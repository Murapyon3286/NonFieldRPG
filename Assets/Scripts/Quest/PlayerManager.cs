using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerManager : MonoBehaviour
{
	static PlayerManager Instance = null;

	static public PlayerManager GetInstance()
	{
		if (Instance == null)
		{
			Instance = new PlayerManager();
		}
		return Instance;
	}

	[SerializeField] public int hp;
	[SerializeField] public int at;

	// UŒ‚‚·‚é
	public int Attack(EnemyManager enemy)
  {
    int damage = enemy.Damage(at);
		return damage;
  }

  // ƒ_ƒ[ƒW‚ğó‚¯‚é
  public int Damage(int damage)
  {
    hp -= damage;
    if (hp <= 0)
    {
      hp = 0;
    }
		return damage;
  }

	public void UpAttackPoint()
	{
		at++;
	}

	string SAVEKEY = "PLAYER-SAVE-KEY";

	public void Save()
	{
		PlayerPrefs.SetString(SAVEKEY, JsonUtility.ToJson(this));
		PlayerPrefs.Save();
	}

	public void Load()
	{
		string json = PlayerPrefs.GetString(SAVEKEY, JsonUtility.ToJson(new PlayerManager()));
		Instance = gameObject.AddComponent<PlayerManager>();
		JsonUtility.FromJsonOverwrite(json, Instance);
	}

	public void DeleteSaveData()
	{
		PlayerPrefs.DeleteKey(SAVEKEY);
		PlayerPrefs.Save();
		Load();
	}
}