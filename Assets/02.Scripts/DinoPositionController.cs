using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPositionController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.GetChild(0).localPosition = Vector3.zero;
        for (int i=1; i<=transform.childCount/2; i++)
        {
            float x = 3 * i;
            transform.GetChild(2*i-1).localPosition = Vector3.right * x;
            transform.GetChild(2*i).localPosition = Vector3.left * x;
        }
    }
}
