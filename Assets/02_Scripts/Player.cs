using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //플레이어 데이터를 가질 수 있는 변수
    public PlayerData pData;
    GameObject[] monster;

    public bool back = false;
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
        
    }

    public void NormalAttack()
    {
        if (GameManager.gm.currTurn == false)
        {
            StartCoroutine(NormalAttackRoutine());
        }
    }

    //버튼이 눌렸을 경우 플레이어턴에 담겨있는
    //몬스터들 배열의 랜덤 하게 가서 때리고
    //다시 원래 위치로 돌아오기 위한 코루틴
    IEnumerator NormalAttackRoutine()
    {
        monster = GameObject.FindGameObjectsWithTag("Enemy");
        back = false;//플레이어가 공격하고 돌아왔는지 체크하는 변수
        int r = Random.Range(0, monster.Length);//몬스터 랜덤 타겟팅
        while (true)
        {
            //리지드 바디 무브포지션은 이동과 출발 지점을 설정하여 이동하게 해줌
            //Lerp값을 이용하여 속도를 설정해줄거임
            if(monster[r] != null)
            {
                //랜덤 타깃이 된 몬스터를 향해 이동
                rigi.MovePosition(Vector3.Lerp(transform.position, monster[r].transform.position, 20 * Time.deltaTime));
                //몬스터와의 거리가 0.5이하면  공격 시작
                if(Vector3.Distance(transform.position, monster[r].transform.position) <= 0.5f)
                {
                    //공격 모션
                    //공격 사운드
                    //공격 데미지
                    yield return new WaitForSeconds(0.3f);
                    back = true;
                    break;
                }
                yield return null;
            }
        }
    }
}