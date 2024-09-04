using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�̱���
    public static GameManager gm;

    //��ųʸ� Key ��, value �� ���� Key�� string, value�� GameObject
    public Dictionary<string, GameObject> d_Player = new Dictionary<string, GameObject>();
    //���ʹ� ����Ʈ�� �������
    public List<GameObject> monsterList = new List<GameObject>();
    //���� ����Ʈ�� ����� ���͵��� �迭
    public GameObject[] monster;

    //�ϳ��� ��ũ��Ʈ�� �������� �����͸� ���� ���ֱ� ���� �۾� ����� �ϳ��� ��ųʸ�
    //���� ĳ���͸� �����ؾ��ϴ� �� ĳ���͸� ��ƾ� �Ѵ�.(�迭 or ����Ʈ)
    [Header("�÷��̾� �������ͽ� ����")]
    public GameObject[] players;
    //���� ĳ������ data�� �� ĳ������ �ش� StatusPanel�ȿ� �ִ� Status Text�� ����
    public GameObject[] status;
    public Text[] swordText;
    public Text[] priestText;
    public Text[] witchText;
    
    //��Ÿ�� Ŭ���� �ν��Ͻ��� ���� ����
    CoolTime ct;

    //�� ��Ÿ���� ���� ����
    [Header("�� ����")]
    public Slider turn;
    public Text turnText;
    //���� ��Ÿ��
    public float turnTime = 10;

    //�� ���� �� ����
    //�÷��̾� ��
    public bool playerTurn = true;
    //���� ��
    public bool monsterTurn = false;
    //���� ��false : �÷��̾��� ture : ������, �ٸ� Ŭ�������� �Ǻ��� ������ ����
    public bool currTurn = false;
    
    private void Awake()
    {
        gm = this;
        //��Ÿ�� Ŭ���� �ν��Ͻ�ȭ
        ct = new CoolTime();
    }

    void Start()
    {
        status = GameObject.FindGameObjectsWithTag("Status");
        //��ųʸ��� �÷��̾���� �����
        d_Player.Add("�˻�", players[0]);
        d_Player.Add("������Ʈ", players[1]);
        d_Player.Add("������", players[2]);
        //���͵��� �����
        monsterList.Add(monster[0]);
        monsterList.Add(monster[1]);
        monsterList.Add(monster[2]);

        swordText = status[0].GetComponentsInChildren<Text>();
        priestText = status[1].GetComponentsInChildren<Text>();
        witchText = status[2].GetComponentsInChildren<Text>();
    }
    
    void Update()
    {
        //�������� turn�̶�� �����̴� value ����
        //coolTime class�Լ� Timer�� ȣ���Ͽ�
        //turnTime���� �����Ͽ� �ð��� �귯���� ��
        turn.value = ct.Timer(turnTime);
        //�� ���� �Լ�
        Turn();
        //�÷��̾� ĳ���͵��� �������ͽ� ǥ�� �Լ�
        StatusShow();
    }

    void Turn()
    {
        if(turn.value == 0)//�����̴��� ������ ���������� ���� ��
        {
            playerTurn = !playerTurn;
            currTurn = !playerTurn;
            if (playerTurn)
            {
                //�÷��̾� ��
                turnText.text = "Player Turn";
                monsterTurn = false;
            }
            else
            {
                //���� ��
                turnText.text = "Monster Turn";
                playerTurn = false;
            }
        }
        //���� �̷��� �ϸ� false true ������ ���� ����
        Debug.Log("���� �� : " + currTurn);
    }

    void StatusShow()
    {
        //�˻� �������ͽ�
        if (d_Player.ContainsKey("�˻�"))
        {
            Player p1 = d_Player["�˻�"].GetComponent<Player>();
            if(p1 != null)
            {
                swordText[0].text ="���� : " + p1.pData.jop;
                swordText[1].text = "���� : " + p1.pData.level;
                swordText[2].text = "����ġ : " + p1.pData.exp;
                swordText[3].text = "HP : " + p1.pData.hp + " / " + p1.pData.maxHp;
                swordText[4].text = "MP : " + p1.pData.mp + " / " + p1.pData.maxMp;
            }
        }

        //������Ʈ �������ͽ�
        if (d_Player.ContainsKey("������Ʈ"))
        {
            Player p2 = d_Player["������Ʈ"].GetComponent<Player>();
            if (p2 != null)
            {
                priestText[0].text = "���� : " + p2.pData.jop;
                priestText[1].text = "���� : " + p2.pData.level;
                priestText[2].text = "����ġ : " + p2.pData.exp;
                priestText[3].text = "HP : " + p2.pData.hp + " / " + p2.pData.maxHp;
                priestText[4].text = "MP : " + p2.pData.mp + " / " + p2.pData.maxMp;
            }
        }

        //������ �������ͽ�
        if (d_Player.ContainsKey("������"))
        {
            Player p3 = d_Player["������"].GetComponent<Player>();
            if (p3 != null)
            {
                witchText[0].text = "���� : " + p3.pData.jop;
                witchText[1].text = "���� : " + p3.pData.level;
                witchText[2].text = "����ġ : " + p3.pData.exp;
                witchText[3].text = "HP : " + p3.pData.hp + " / " + p3.pData.maxHp;
                witchText[4].text = "MP : " + p3.pData.mp + " / " + p3.pData.maxMp;
            }
        }
    }
}