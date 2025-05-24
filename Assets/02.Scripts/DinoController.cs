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

    }
}
