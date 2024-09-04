using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager gm;

    //딕셔너리 Key 값, value 값 지정 Key는 string, value는 GameObject
    public Dictionary<string, GameObject> d_Player = new Dictionary<string, GameObject>();
    //몬스터는 리스트로 만들거임
    public List<GameObject> monsterList = new List<GameObject>();
    //몬스터 리스트에 담아줄 몬스터들의 배열
    public GameObject[] monster;

    //하나의 스크립트로 여러개의 데이터를 관리 해주기 위한 작업 방법중 하나인 딕셔너리
    //여러 캐릭터를 제어해야하니 각 캐릭터를 담아야 한다.(배열 or 리스트)
    [Header("플레이어 스테이터스 변수")]
    public GameObject[] players;
    //담은 캐릭터의 data를 각 캐릭터의 해당 StatusPanel안에 있는 Status Text에 적용
    public GameObject[] status;
    public Text[] swordText;
    public Text[] priestText;
    public Text[] witchText;
    
    //쿨타임 클래스 인스턴스를 위한 변수
    CoolTime ct;

    //턴 쿨타임을 위한 변수
    [Header("턴 변수")]
    public Slider turn;
    public Text turnText;
    //실제 쿨타임
    public float turnTime = 10;

    //턴 설정 불 변수
    //플레이어 턴
    public bool playerTurn = true;
    //몬스터 턴
    public bool monsterTurn = false;
    //현재 턴false : 플레이어턴 ture : 몬스터턴, 다른 클래스에서 판별할 현재턴 설정
    public bool currTurn = false;
    
    private void Awake()
    {
        gm = this;
        //쿨타임 클래스 인스턴스화
        ct = new CoolTime();
    }

    void Start()
    {
        status = GameObject.FindGameObjectsWithTag("Status");
        //딕셔너리로 플레이어들을 담아줌
        d_Player.Add("검사", players[0]);
        d_Player.Add("프리스트", players[1]);
        d_Player.Add("마법사", players[2]);
        //몬스터들을 담아줌
        monsterList.Add(monster[0]);
        monsterList.Add(monster[1]);
        monsterList.Add(monster[2]);

        swordText = status[0].GetComponentsInChildren<Text>();
        priestText = status[1].GetComponentsInChildren<Text>();
        witchText = status[2].GetComponentsInChildren<Text>();
    }
    
    void Update()
    {
        //지정해준 turn이라는 슬라이더 value 값에
        //coolTime class함수 Timer를 호출하여
        //turnTime값을 대입하여 시간이 흘러가게 함
        turn.value = ct.Timer(turnTime);
        //턴 구분 함수
        Turn();
        //플레이어 캐릭터들의 스테이터스 표시 함수
        StatusShow();
    }

    void Turn()
    {
        if(turn.value == 0)//슬라이더가 끝까지 도달했으면 다음 턴
        {
            playerTurn = !playerTurn;
            currTurn = !playerTurn;
            if (playerTurn)
            {
                //플레이어 턴
                turnText.text = "Player Turn";
                monsterTurn = false;
            }
            else
            {
                //몬스터 턴
                turnText.text = "Monster Turn";
                playerTurn = false;
            }
        }
        //현재 이렇게 하면 false true 값으로 나와 버림
        Debug.Log("현재 턴 : " + currTurn);
    }

    void StatusShow()
    {
        //검사 스테이터스
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

        //프리스트 스테이터스
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

        //마법사 스테이터스
        if (d_Player.ContainsKey("마법사"))
        {
            Player p3 = d_Player["마법사"].GetComponent<Player>();
            if (p3 != null)
            {
                witchText[0].text = "직업 : " + p3.pData.jop;
                witchText[1].text = "레벨 : " + p3.pData.level;
                witchText[2].text = "경험치 : " + p3.pData.exp;
                witchText[3].text = "HP : " + p3.pData.hp + " / " + p3.pData.maxHp;
                witchText[4].text = "MP : " + p3.pData.mp + " / " + p3.pData.maxMp;
            }
        }
    }
}