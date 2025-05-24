using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFollowCamera : MonoBehaviour
{
    public Transform target; // 따라갈 오브젝트 (Dino)
    private float offset; // 카메라와 Dino 사이의 거리
    void Start()
    {
        offset = target.position.z - transform.position.z; // 타겟과 카메라 사이의 거리
    }

    void LateUpdate()
    {
        if(target != null)
        {
            // 카메라의 새로운 위치 계산
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z - offset);

            // 카메라 위치 없데이트
            transform.position = newPosition;
        }
    }
}
