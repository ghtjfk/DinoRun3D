using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DinoController : MonoBehaviour
{
    public float runSpeed;
    public float xMoveSpeed;
    void Start()
    {

    }

    void Update()
    {
        // �������� �ڵ�
        transform.position += Vector3.forward * runSpeed * Time.deltaTime;

        // �ۼ��� ��� 1 (���� ���)
        // transform.Translate(0, 0, runSpeed * Time.deltaTime);

        // �ۼ��� ��� 2 (ó�� �غ� ���)
        // transform.position += new Vector3(0, 0, runSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * xMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * xMoveSpeed * Time.deltaTime;
        }

    }
}
