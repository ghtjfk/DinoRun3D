using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPositionController : MonoBehaviour
{
    public Transform raptors;   // Raptor들을 관리할 부모 오브제그의 Transform
    public GameObject raptorPrefab;  // 추가할 Raptor 프리팹

    // 황금각 배치 알고리즘
    public int visibleRaptorNumber; // 보여주고 싶은 Raptor의 수를 입력
    public float initialRadius = 0f; // 첫 오브젝트의 반지름
    public float radiusGrowth = 0.12f; // 오브젝트 간 반지름 증가량
    public float angleIncrement = 137.508f; // 각도 증가 비율 (보통 골든 앵글 사용)
    
    /*원형 배치 알고리즘
    public float radius = 1f;   // 원의 반지름
    public float ratio = 1f;  // 배치 간격 비율 (작을수록 촘촘하게)
    */
    void Start()
    {
        
    }

    void Update()
    {
        SetDinoPosition();
    }

    public void SetDoorCalc(DoorType doorType, int doorNumber)
    {
        if (doorType.Equals(DoorType.Plus))
        {
            PlusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Minus))
        {
            MinusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Times))
        {
            TimesRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Division))
        {
            DivisionRaptor(doorNumber);
        }
    }

    private void PlusRaptor(int number)
    {
        for(int i = 0; i < number; i++)
        {
            Instantiate(raptorPrefab, raptors);
        }
    }

    private void MinusRaptor(int number)
    {
        // 빼서 0보다 작아지는 것 방지
        if (raptors.childCount < number)
        {
            number = raptors.childCount;
        }

        for (int i = 0; i < number; i++)
        {
            Destroy(raptors.GetChild(raptors.childCount - 1 - i).gameObject);
        }
    }

    private void TimesRaptor(int number)
    {
        // 곱하기 -> k번 더하는 것으로 구현
        int k = raptors.childCount * (number - 1);
        for(int i = 0; i < k; i++)
        {
            Instantiate(raptorPrefab, raptors);
        }
    }

    private void DivisionRaptor(int number)
    {
        // 나누기 -> k번 빼는 것으로 구현
        int k = raptors.childCount - raptors.childCount / number;
        for (int i = 0; i < k; i++)
        {
            if (raptors.childCount > 0)
            {
                Destroy(raptors.GetChild(raptors.childCount - 1 - i).gameObject);
            }
        }
    }

    private void SetDinoPosition()
    {
        // 황금각 배치 알고리즘
        for (int i = 0; i < raptors.childCount; i++)
        {
            if (i > visibleRaptorNumber - 1) // 보여주고 싶은 개수를 입력받은오브젝트보다 크면 화면에 안보이게 함 (i는 0부터 시작되므로 입력받은 수에서 1을 빼줘야 한다)
            {
                raptors.GetChild(i).gameObject.SetActive(false); // visibleRaptorNumber 보다 큰 오브젝트부터는 화면에 보이지 않게 함
                continue; // 이 아래의 계산은 하지 않는다. 즉 continue 아래에 있는 코드들은 실행되지 않고, 바로 다음 루프(iteration)로 넘어감
            }

            // 반지름이 점점 커짐 피보나치 수열 효과
            float currentRadius = initialRadius + (radiusGrowth * i);
            // 각도가 점점 증가 (오브젝트가 계속 나선형으로 퍼져나감)
            float angle = i * angleIncrement;
            // 각도를 라디안 단위로 변환 후 좌표 계산
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * currentRadius;
            float z = Mathf.Sin(angle * Mathf.Deg2Rad) * currentRadius;
            // 위치 설정
            raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
            raptors.GetChild(i).gameObject.SetActive(true); // visibleRaptorNumber보다 작은 오브젝트부터는 화면에 보이게 함
        }


        /* 원형 배치 알고리즘
        for(int i=0; i<raptors.childCount; i++)
        {
            if(i < 9)   // 9번째 공룡까지만 화면에 송출
            {
                if (raptors.childCount <= 9)    // 공룡 개수가 9개 이하일 때만 화면에 배치
                {
                    // 360도 각도 계산을 위한 각도 증가 값 (몇개가 배치될지 계산 값) (배치될 오브젝트들의 각도 간격)
                    float angleSetp = 360f / (raptors.childCount * ratio);

                    // 각 오브젝트의 배치 각도 계산
                    float angle = i * angleSetp;

                    // 각도를 라디안으로 변환
                    float angleRad = Mathf.Deg2Rad * angle;
                    // "Mathf.Rad2Deg"는 반대로 라디안을 각도로 변환하는 것

                    // X와 Z 좌표를 원형으로 계산
                    float x = Mathf.Cos(angleRad) * radius;
                    float z = Mathf.Sin(angleRad) * radius;

                    // 새로운 위치로 자식 오브젝트를 위치시킴
                    raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
                }
            }
            else  // 10번째 공룡부터 화면에 송출 안함
            {
                raptors.GetChild(i).gameObject.SetActive(false);
            }
        } */
    }
}
