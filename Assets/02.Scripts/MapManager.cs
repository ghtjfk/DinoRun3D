using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapPrefabs;
    int ranVal;
    int insPoint = 0;   // map 생성 포인트
    int mapZ;   // 더해나갈 값
    bool firstMap = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ranVal = Random.Range(0, mapPrefabs.Length);
            mapZ = (int)mapPrefabs[ranVal].GetComponent<Map>().mapSize.z;
            // 첫번째 맵은 처음 더할 게 없으므로 예외 처리.
            if (firstMap)
            {
                insPoint -= mapZ / 2;
                firstMap = false;
            }
            insPoint += mapZ / 2;   // 더하고,
            Instantiate(mapPrefabs[ranVal], new Vector3(0, 0, insPoint), Quaternion.identity);  //생성하고,
            insPoint += mapZ / 2;   // 더하기.
        }
    }
}
