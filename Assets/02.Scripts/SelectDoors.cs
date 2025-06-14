using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum DoorType
{
    Plus,
    Minus,
    Times,
    Division
}

public class SelectDoors : MonoBehaviour
{
    public SpriteRenderer rightDoorSpriteRD;  // 오른쪽 문의 색을 관리할 변수
    public SpriteRenderer leftDoorSpriteRD;  // 왼쪽 문의 색을 관리할 변수
    public TextMeshPro rightDoorText;        // 오른쪽 문의 Text를 관리할 변수 
    public TextMeshPro leftDoorText;        // 왼쪽 문의 Text를 관리할 변수

    [SerializeField]    // private 필드를 인스펙터에서 수정 가능하도록 노출시켜주는 특성
    private DoorType rightDoorType;  // 오른쪽 문의 상태(+ or -)를 관리할 변수
    public int rightDoorNumber;      // 오른쪽 문에서 계산될 숫자 변수

    [SerializeField]
    private DoorType leftDoorType;  // 왼쪽 문의 상태(+ or -)를 관리할 변수
    public int leftDoorNumber;      // 왼쪽 문에서 계산될 숫자 변수

    public Color goodColor;  // 플러스 문의 색상
    public Color badColor;  // 마이너스 문의 색상

    void Start()
    {
        SettingDoors();
    }

    void Update()
    {
        
    }

    public void SettingDoors()
    {
        // 오른쪽 문 세팅
        if (rightDoorType.Equals(DoorType.Plus))
        {
            // 플러스일 때
            rightDoorSpriteRD.color = goodColor;
            rightDoorText.text = "+" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Minus))
        {
            // 마이너스일 때
            rightDoorSpriteRD.color = badColor;
            rightDoorText.text = "-" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Times))
        {
            // 곱하기일 때
            rightDoorSpriteRD.color = goodColor;
            rightDoorText.text = "×" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Division))
        {
            // 나누기일 때
            rightDoorSpriteRD.color = badColor;
            rightDoorText.text = "÷" + rightDoorNumber;
        }

        // 왼쪽 문 세팅
        if (leftDoorType.Equals(DoorType.Plus))
        {
            // 플러스일 때
            leftDoorSpriteRD.color = goodColor;
            leftDoorText.text = "+" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Minus))
        {
            // 마이너스일 때
            leftDoorSpriteRD.color = badColor;
            leftDoorText.text = "-" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Times))
        {
            // 곱하기일 때
            leftDoorSpriteRD.color = goodColor;
            leftDoorText.text = "×" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Division))
        {
            // 나누기일 때
            leftDoorSpriteRD.color = badColor;
            leftDoorText.text = "÷" + leftDoorNumber;
        }
    }

    public DoorType GetDoorType(float xPos)
    {
        if(xPos > 0)
        {
            return rightDoorType;
        }
        else
        {
            return leftDoorType;
        }
    }

    public int GetDoorNumber(float xPos)
    {
        if (xPos > 0)
        {
            return rightDoorNumber;
        }
        else
        {
            return leftDoorNumber;
        }
    }
}
