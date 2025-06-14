using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPositionController : MonoBehaviour
{
    public Transform raptors;   // Raptor들을 관리할 부모 오브제그의 Transform
    public GameObject raptorPrefab;  // 추가할 Raptor 프리팹

    public float radius = 1f;   // 원의 반지름
    public float ratio = 1f;  // 배치 간격 비율 (작을수록 촘촘하게)

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


        }
        else if (doorType.Equals(DoorType.Times))
        {


        }
        else if (doorType.Equals(DoorType.Division))
        {


        }
    }

    private void PlusRaptor(int number)
    {
        for(int i = 0; i < number; i++)
        {
            Instantiate(raptorPrefab, raptors);
        }
    }

    private void SetDinoPosition()
    {
        // 원형 배치 알고리즘
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
        }
    }
}
