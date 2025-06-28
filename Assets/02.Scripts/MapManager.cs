using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    public StageScriptableObject[] stages;  // 스크립터블 오브젝트를 만든 Data를 담기 위한 변수

    public GameObject goalObject;

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

    void Start()
    {
        CreateStage();
        goalObject = GameObject.FindWithTag("Goal");   // 찾아서 대입
    }

    public int GetStage()
    {
        return PlayerPrefs.GetInt("Stage", 1);
    }

    public float GetGoalDistance()
    {
        return goalObject.transform.position.z;
    }

    private void CreateStage()
    {
        int currentStageIndex = GetStage();
        currentStageIndex = currentStageIndex % stages.Length;  // 이렇게 하면 stages의 범위를 벗어나는 경우가 없다.
        StageScriptableObject stage = stages[currentStageIndex];

        CreateMap(stage.maps);
    }

    private void CreateMap(Map[] stageMaps)
    {
        Vector3 mapPosition = Vector3.zero;

        for (int i = 0; i < stageMaps.Length; i++)
        {
            Map selectedMap = stageMaps[i]; // 만들 Map을 순서대로 선택한다.
            if (i > 0)
            {
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSizeZ() / 2;
            }
            Map nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity, transform);
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSizeZ() / 2;
        }
    }

    /*private void CreatTestMap()
    {
        for (int i = 0; i < testMapPrefabs.Length; i++)
        {
            mapZ = (int)testMapPrefabs[i].GetComponent<Map>().mapSize.z;

            if (i > 0)  // 첫번째 맵 제외
            {
                insPoint += mapZ / 2;   // 더하고,
            }

            Instantiate(testMapPrefabs[i], new Vector3(0, 0, insPoint), Quaternion.identity);  //생성하고,
            insPoint += mapZ / 2;   // 더하기.
        }
    }

    private void CreatMap()
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
    }*/
}
