using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerData", fileName = "Player Data", order = 0)]
public class PlayerData : ScriptableObject
{
    public string playerName;//�÷��̾� �̸�
    public string jop;//����
    public int level;//����
    public int exp;//����ġ
    public int attack;//���ݷ�
    public int hp;//���� ü��
    public int maxHp;//�ִ� ü��
    public int mp;//���� ����
    public int maxMp;//�ִ� ����
}