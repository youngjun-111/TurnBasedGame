using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //�÷��̾� �����͸� ���� �� �ִ� ����
    public PlayerData pData;
    GameObject[] monster;

    public bool back = false;
    //�ٽ� ���ƿ��� ���� ���� �Һ���
    public bool home = true;


    public Vector3 oriPos;
    Animator anim;
    Rigidbody2D rigi;
    void Start()
    {
        monster = GameObject.FindGameObjectsWithTag("Enemy");
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        oriPos = transform.position;
    }

    void Update()
    {
        if(back == true)
        {
            rigi.MovePosition(Vector3.Lerp(transform.position, oriPos, 20 * Time.deltaTime));
            //���� ���ƿ��µ� ��ġ�� ���� ��ġ���� 0.5���� �Դٸ� �ʱ���ġ�� ���ְ�
            //��(���� ��ġ)�̶�� ��� ����
            if (Vector3.Distance(transform.position, oriPos) <= 0.5f)
            {
                transform.position = oriPos;
                home = true;
            }
        }
    }

    public void NormalAttack()
    {
        if (GameManager.gm.currTurn == false)
        {
            StartCoroutine(NormalAttackRoutine());
        }
    }

    //��ư�� ������ ��� �÷��̾��Ͽ� ����ִ�
    //���͵� �迭�� ���� �ϰ� ���� ������
    //�ٽ� ���� ��ġ�� ���ƿ��� ���� �ڷ�ƾ
    IEnumerator NormalAttackRoutine()
    {
        monster = GameObject.FindGameObjectsWithTag("Enemy");
        back = false;//�÷��̾ �����ϰ� ���ƿԴ��� üũ�ϴ� ����
        int r = Random.Range(0, monster.Length);//���� ���� Ÿ����
        while (true)
        {
            //������ �ٵ� ������������ �̵��� ��� ������ �����Ͽ� �̵��ϰ� ����
            //Lerp���� �̿��Ͽ� �ӵ��� �������ٰ���
            if(monster[r] != null)
            {
                //����ġ �ƴ� �� �� ��ư�� ���� �߰������� �ڷ�ƾ�� ȣ�� �ȵǰ�
                home = false;
                //���� Ÿ���� �� ���͸� ���� �̵�
                rigi.MovePosition(Vector3.Lerp(transform.position, monster[r].transform.position, 20 * Time.deltaTime));
                //���Ϳ��� �Ÿ��� 0.5���ϸ�  ���� ����
                if(Vector3.Distance(transform.position, monster[r].transform.position) <= 0.5f)
                {
                    //���� ���
                    //���� ����
                    //���� ������
                    yield return new WaitForSeconds(0.3f);
                    back = true;
                    break;
                }
                yield return null;
            }
        }
    }
}