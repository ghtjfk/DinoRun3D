using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoController : MonoBehaviour
{
    public static DinoController instance;

    public float runSpeed;
    public float xMoveSpeed;

    public Vector3 sphereCenter;  // 구체의 중심이 될 위치
    public float sphereRadius;    // 구체의 반지름

    public DinoPositionController dinoPositionController;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        if (GameManager.instance.isGameStart.Equals(true))
        {
            DinoMove();
            DoorCheck();
        }
    }

    private void DinoMove()
    {
        // 선생님의 코드
        transform.position += Vector3.forward * runSpeed * Time.deltaTime;

        // 작성한 방법 1 (기존 방식)
        // transform.Translate(0, 0, runSpeed * Time.deltaTime);

        // 작성한 방법 2 (처음 해본 방식)
        // transform.position += new Vector3(0, 0, runSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * xMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * xMoveSpeed * Time.deltaTime;
        }

        // 기존 방식
        /*if(transform.position.x >= 3.5f)
        {
            transform.position = new Vector3(3.5f, 0, transform.position.z);
        }

        if (transform.position.x <= -3.5f)
        {
            transform.position = new Vector3(-3.5f, 0, transform.position.z);
        }*/


        // 새로운 방식
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.8f, 3.8f), 0, transform.position.z);
    }

    private void DoorCheck()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + sphereCenter, sphereRadius);

        // 감지된 Collider 처리
        foreach (Collider doors in hitColliders)
        {
            if (doors.CompareTag("Goal"))
            {
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 1);   // 현재 Stage에서 1 더하여 저장
                doors.gameObject.GetComponent<BoxCollider>().enabled = false;   // door의 BoxCollider 비활성화
                GameManager.instance.StageClear();
            }

            else if(doors.gameObject.GetComponent<SelectDoors>() != null)
            {
                SoundManager.instance.DoorHitSoundPlay(); // 효과음 실행
                // x값에 따른 type과 number 받아오기
                DoorType doorType = doors.gameObject.GetComponent<SelectDoors>().GetDoorType(transform.position.x);
                int doorNumber = doors.gameObject.GetComponent<SelectDoors>().GetDoorNumber(transform.position.x);

                // 선생님 방법
                doors.gameObject.GetComponent<BoxCollider>().enabled = false;
                /* 내 방법 => 안되는 이유 => Trigger를 꺼도 OverlapSphere() 같은 감지 함수에서는 여전히 잡힙니다. => Collider 자체를 비활성화 시키자!
                doors.isTrigger = false; */

                // 받아온 값으로 계산해주기
                dinoPositionController.SetDoorCalc(doorType, doorNumber);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + sphereCenter, sphereRadius);
    }
}