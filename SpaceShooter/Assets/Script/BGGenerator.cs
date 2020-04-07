using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// reference: https://www.youtube.com/watch?v=NtY_R0g8L8E
public class BGGenerator : MonoBehaviour
{
    [SerializeField] private float MIN_OUT_OF_SCREEN_DISTANCE = 15f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelList;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int startingSpawnLevelParts = 3;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("END").position;

        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackground();
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelList[Random.Range(0, levelList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("END").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosistion)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosistion, Quaternion.identity);
        return levelPartTransform;
    }

    private void MoveBackground()
    {
        GameObject[] bgs = GameObject.FindGameObjectsWithTag("Background");
        foreach (GameObject bg in bgs)
        {
            bg.transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
            // Destroy bg when out of scene
            if (bg.transform.position.y < -MIN_OUT_OF_SCREEN_DISTANCE)
            {
                lastEndPosition.y -= MIN_OUT_OF_SCREEN_DISTANCE;
                SpawnLevelPart();
                SpawnLevelPart();
                Destroy(bg);
            }
        }
    }
}
