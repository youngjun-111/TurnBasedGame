using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerData", fileName = "Player Data", order = 0)]
public class PlayerData : ScriptableObject
{
    public string playerName;//플레이어 이름
    public string jop;//직업
    public int level;//레벨
    public int exp;//경험치
    public int attack;//공격력
    public int hp;//현재 체력
    public int maxHp;//최대 체력
    public int mp;//현재 마나
    public int maxMp;//최대 마나
}