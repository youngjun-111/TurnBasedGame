using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolTime
{
    public float coolTime;
    float coolCnt = 0;

    void Start()
    {
        coolCnt = Time.time;
    }

    public float Timer (float t)
    {
        //Ÿ�̸� ������ �ð��� �����ϸ� ����
        //t�� ���ڷ� �޾� �װ� ��ŭ Time.time�� �����ϸ�
        //��� ����
        //t�� 10�̶�� 10�ʸ��� ����
        //10�ʸ��� coolTime�� 0���� �ʱ�ȭ
        coolTime += Time.deltaTime;

        if(coolCnt + t <= Time.time)
        {
            //����ð� + ���ڰ��� t�� �귯�� �ð��� �ʰ��Ͽ��� ���
            //���� �ð��� �ٽ� Time.time���� �ʱ�ȭ �ϰ�
            coolCnt = Time.time;
            //��Ÿ���� 0 ���� �ʱ�ȭ �����༭ �ٽ� �귯���� ������
            coolTime = 0;
        }

        return coolTime;
    } 
}
