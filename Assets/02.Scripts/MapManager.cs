using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapPrefabs;
    int ranVal;
    int insPoint = 0;   // map 생성 포인트
    int mapZ;   // 더해나갈 값

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            // 첫번째는 Map3으로 고정
            if (i == 0)
            {
                // Map3으로 고정
                mapZ = (int)mapPrefabs[0].GetComponent<Map>().mapSize.z;

                // 첫번째 맵은 처음 더할 게 없음
                // 생성 + 더하기
                Instantiate(mapPrefabs[0], new Vector3(0, 0, insPoint), Quaternion.identity);  //생성하고,
                insPoint += mapZ / 2;   // 더하기.
            }

            // 마지막은 GoalMap으로 고정
            else if (i == 4)
            {
                // GoalMap으로 고정
                mapZ = (int)mapPrefabs[7].GetComponent<Map>().mapSize.z;

                // 더하기 + 생성하고 + 더하기
                insPoint += mapZ / 2;   // 더하고,
                Instantiate(mapPrefabs[7], new Vector3(0, 0, insPoint), Quaternion.identity);  //생성하고,
                insPoint += mapZ / 2;   // 더하기.
            }

            // 나머지는 랜덤 선택
            else
            {
                // 랜덤 선택
                ranVal = Random.Range(0, mapPrefabs.Length - 1);
                mapZ = (int)mapPrefabs[ranVal].GetComponent<Map>().mapSize.z;

                // 더하기 + 생성하고 + 더하기
                insPoint += mapZ / 2;   // 더하고,
                Instantiate(mapPrefabs[ranVal], new Vector3(0, 0, insPoint), Quaternion.identity);  //생성하고,
                insPoint += mapZ / 2;   // 더하기.
            }
        }
    }

    void Update()
    {
        
    }
}
