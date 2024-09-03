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

    //�ϳ��� ��ũ��Ʈ�� �������� �����͸� ���� ���ֱ� ���� �۾� ���
    //���� ĳ���͸� �����ؾ��ϴ� �� ĳ���͸� ��ƾ� �Ѵ�.(�迭 or ����Ʈ)
    public GameObject[] players;
    //���� ĳ������ data�� �� ĳ������ �ش� StatusPanel�ȿ� �ִ� Status Text�� ����
    public GameObject[] status;
    public Text[] swordText;
    public Text[] priestText;
    public Text[] withchText;
    //��ųʸ� Key ��, value �� ���� Key�� GameObject, value�� string

    void Start()
    {
        status = GameObject.FindGameObjectsWithTag("Status");
        d_Player.Add("�˻�", players[0]);
        d_Player.Add("������Ʈ", players[1]);
        d_Player.Add("������", players[2]);

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
        //�˻�
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
        //������Ʈ
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
        //������
        if (d_Player.ContainsKey("������"))
        {
            Player p3 = d_Player["������"].GetComponent<Player>();
            if (p3 != null)
            {
                withchText[0].text = "���� : " + p3.pData.jop;
                withchText[1].text = "���� : " + p3.pData.level;
                withchText[2].text = "����ġ : " + p3.pData.exp;
                withchText[3].text = "HP : " + p3.pData.hp + " / " + p3.pData.maxHp;
                withchText[4].text = "MP : " + p3.pData.mp + " / " + p3.pData.maxMp;
            }
        }
    }
}