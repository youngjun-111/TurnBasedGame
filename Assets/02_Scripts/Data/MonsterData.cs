using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/MonsterData", fileName = "Monster Data", order = 0)]
public class MonsterData : ScriptableObject
{
    public string monsterName;//������ �̸�
    public string jop;//������ ����
    public int attack;//������ ���ݷ�
    public int hp;//������ ���� ü��
    public int maxHp;//������ �ִ� ü��
    public int mp;//������ ���� ����
    public int maxMp;//������ �ִ� ����
    public int level;//������ ����
    public int exp;//������ ����ġ
}