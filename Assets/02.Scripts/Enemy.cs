using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State
    {
        Idle,   // 대기 상태에서 애니메이션 작동 멈춘 상태
        Run     // Raptor에게 달려가는 상태
    }

    public float moveSpeed;
    public float detectRadius;  // 감지되는 범위의 반지름
    private State state;    // 적의 상태를 나타낼 변수
    private Transform targetRaptor;     // 타겟이 될 Raptor

    void Start()
    {
        GetComponent<Animator>().speed = 0f;    // 처음은 가만히 대기함
    }

    void Update()
    {
        SetState();
    }

    private void SetState()
    {
        switch (state)
        {
            case State.Idle:
                DetectDino();
                break;

            case State.Run:
                GoToDino();
                break;      
        }
    }

    private void DetectDino()   // Dino를 찾고 있는 함수, 항상 Update에서 작동되고 있음.
    {
        // 구체 영역 내의 Collider들을 감지
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectRadius);

        // 감지된 Collider들 처리
        foreach (Collider colls in hitColliders)
        {
            // 검색된 곳에 Dino가 있다면
            if(colls.gameObject.GetComponent<Raptor>() != null)
            {
                if (colls.gameObject.GetComponent<Raptor>().IsTarget()) continue;   // 이미 타겟으로 지정되어 있다면, 다음 충돌 오브젝트로

                colls.gameObject.GetComponent<Raptor>().SetTarget();    // 충돌 오브젝트에 타겟으로 지정됐다고 스위치 켜주기

                targetRaptor = colls.gameObject.transform;  // 충돌 오브젝트를 targetRaptor로 지정

                StartGoToDino();    // 상태 바꿔주기
            }
        }
    }

    private void StartGoToDino()    // 찾았을 때 작동하는 함수
    {
        state = State.Run;  // Run으로 변경
        GetComponent<Animator>().speed = 1f;    // 애니메이션 시간을 원래 시간으로 되돌리기
    }

    private void GoToDino()     // 찾고난 후 dino에게 달려가는 함수
    {
        if(targetRaptor == null)    //타겟이 없다면 작동X
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetRaptor.position, Time.deltaTime * moveSpeed);

        if(Vector3.Distance(transform.position, targetRaptor.position) < 0.1f)
        {
            Destroy(targetRaptor.gameObject);   // targetRaptor 삭제
            Destroy(this.gameObject);   // Enemy인 나 자신도 삭제
        }
    }
}
