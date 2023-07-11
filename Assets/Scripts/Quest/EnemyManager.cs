using System;
using UnityEngine;
using DG.Tweening;

// �G���Ǘ�������́i�X�e�[�^�X�E�N���b�N���o�j
public class EnemyManager : MonoBehaviour
{
  // �֐��o�^
  Action tapAction; // �N���b�N���ꂽ�Ƃ��Ɏ��s�������֐��i�O������ݒ肵�����j

  public new string name;
  public int hp;
  public int at;

  // �U������
  public void Attack(PlayerManager player)
  {
    player.Damage(at);
  }

  // �_���[�W���󂯂�
  public void Damage(int damage)
  {
		transform.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
    hp -= damage;
    if (hp <= 0)
    {
      hp = 0;
    }
  }

  // tapAction�Ɋ֐���o�^����֐������
  public void addEventListenerOnTap(Action action)
  {
    tapAction += action;
  }

  public void OnTap()
  {
    Debug.Log("�N���b�N���ꂽ");
    tapAction();
  }
}
