using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/MonsterData", fileName = "Monster Data", order = 0)]
public class MonsterData : ScriptableObject
{
    public string monsterName;//몬스터의 이름
    public string jop;//몬스터의 직업
    public int attack;//몬스터의 공격력
    public int hp;//몬스터의 현재 체력
    public int maxHp;//몬스터의 최대 체력
    public int mp;//몬스터의 현재 마나
    public int maxMp;//몬스터의 최대 마나
    public int level;//몬스터의 레벨
    public int exp;//몬스터의 경험치
}