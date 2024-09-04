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
        //타이머 지정한 시간에 도달하면 실행
        //t를 인자로 받아 그값 만큼 Time.time에 도달하면
        //명령 실행
        //t가 10이라면 10초마다 실행
        //10초마다 coolTime은 0으로 초기화
        coolTime += Time.deltaTime;

        if(coolCnt + t <= Time.time)
        {
            //현재시간 + 인자값인 t가 흘러간 시간을 초과하였을 경우
            //현재 시간을 다시 Time.time으로 초기화 하고
            coolCnt = Time.time;
            //쿨타임을 0 으로 초기화 시켜줘서 다시 흘러가게 해줬음
            coolTime = 0;
        }

        return coolTime;
    } 
}
