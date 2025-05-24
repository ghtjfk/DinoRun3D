using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFollowCamera : MonoBehaviour
{
    public Transform target; // ���� ������Ʈ (Dino)
    private float offset; // ī�޶�� Dino ������ �Ÿ�
    void Start()
    {
        offset = target.position.z - transform.position.z; // Ÿ�ٰ� ī�޶� ������ �Ÿ�
    }

    void LateUpdate()
    {
        if(target != null)
        {
            // ī�޶��� ���ο� ��ġ ���
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z - offset);

            // ī�޶� ��ġ ������Ʈ
            transform.position = newPosition;
        }
    }
}
