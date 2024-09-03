using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scirptable/PlayerData", fileName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public int level;
    public int exp;
    public int hp;
    public int mp;
}