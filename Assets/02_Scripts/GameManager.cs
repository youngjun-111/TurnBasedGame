using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Dictionary<string, GameObject> d_Player = new Dictionary<string, GameObject>();

    private void Awake()
    {
        gm = this;
    }

    //하나의 스크립트로 여러개의 데이터를 관리 해주기 위한 작업 방법
    //여러 캐릭터를 제어해야하니 각 캐릭터를 담아야 한다.(배열 or 리스트)
    public GameObject[] players;
    //담은 캐릭터의 data를 각 캐릭터의 해당 StatusPanel안에 있는 Status Text에 적용
    public GameObject[] status;
    public Text[] swordText;
    public Text[] priestText;
    public Text[] withchText;
    //딕셔너리 Key 값, value 값 지정 Key는 GameObject, value는 string

    void Start()
    {
        status = GameObject.FindGameObjectsWithTag("Status");
        d_Player.Add("검사", players[0]);
        d_Player.Add("프리스트", players[1]);
        d_Player.Add("마법사", players[2]);

        swordText = status[0].GetComponentsInChildren<Text>();
        priestText = status[1].GetComponentsInChildren<Text>();
        withchText = status[2].GetComponentsInChildren<Text>();
    }
    
    void Update()
    {
        StatusShow();
    }

    void StatusShow()
    {
        //검사
        if (d_Player.ContainsKey("검사"))
        {
            Player p1 = d_Player["검사"].GetComponent<Player>();
            if(p1 != null)
            {
                swordText[0].text ="직업 : " + p1.pData.jop;
                swordText[1].text = "레벨 : " + p1.pData.level;
                swordText[2].text = "경험치 : " + p1.pData.exp;
                swordText[3].text = "HP : " + p1.pData.hp + " / " + p1.pData.maxHp;
                swordText[4].text = "MP : " + p1.pData.mp + " / " + p1.pData.maxMp;
            }
        }
        //프리스트
        if (d_Player.ContainsKey("프리스트"))
        {
            Player p2 = d_Player["프리스트"].GetComponent<Player>();
            if (p2 != null)
            {
                priestText[0].text = "직업 : " + p2.pData.jop;
                priestText[1].text = "레벨 : " + p2.pData.level;
                priestText[2].text = "경험치 : " + p2.pData.exp;
                priestText[3].text = "HP : " + p2.pData.hp + " / " + p2.pData.maxHp;
                priestText[4].text = "MP : " + p2.pData.mp + " / " + p2.pData.maxMp;
            }
        }
        //마법사
        if (d_Player.ContainsKey("마법사"))
        {
            Player p3 = d_Player["마법사"].GetComponent<Player>();
            if (p3 != null)
            {
                withchText[0].text = "직업 : " + p3.pData.jop;
                withchText[1].text = "레벨 : " + p3.pData.level;
                withchText[2].text = "경험치 : " + p3.pData.exp;
                withchText[3].text = "HP : " + p3.pData.hp + " / " + p3.pData.maxHp;
                withchText[4].text = "MP : " + p3.pData.mp + " / " + p3.pData.maxMp;
            }
        }
    }
}