using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mobPrefab;
    public GameObject bossPrefab;
    public int WavesCount = 5;
    public List<GameObject> mobs;
    public float delieBetweenWaves = 3f;
    public int currentWave = 0;
    public GameObject[] spawnPoints;
    public Vector3 mobLook;

    bool waitForMobs = false;
    void Start()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator Spawn()
    {
        mobs.Clear();
        int mobsCount = currentWave * 3;
        for (int i = 0; i < mobsCount; i++)
        {

            int numberOfSpawn = Random.Range(0, spawnPoints.Length);
            yield return new WaitForSeconds(1.2f);
            GameObject m = Instantiate(mobPrefab, GetSpawnPoint(numberOfSpawn), GetSpawnDirection(numberOfSpawn));
            mobs.Add(m);
        }
        waitForMobs = false;
    }

    private void Update()
    {
        if (waitForMobs) return;

        if (mobs.Count == 0 && currentWave < WavesCount)
        {
            currentWave++;
            waitForMobs = true;
            StartCoroutine(NextWave());
        }
        else if(currentWave == WavesCount)
        {
            SpawnBoss();
            gameObject.SetActive(false);
        }
    }

    Vector3 GetSpawnPoint(int numberOfSpawn)
    {
        return spawnPoints[numberOfSpawn].transform.position;
    }

    Quaternion GetSpawnDirection(int numberOfSpawn)
    {
        return Quaternion.Euler(mobLook - spawnPoints[numberOfSpawn].transform.position);
    }

    IEnumerator NextWave()
    {
        float time = 0;
        do
        {
            time += Time.deltaTime;
            yield return null;
        } while (time < delieBetweenWaves);
        StartCoroutine(Spawn());
    }

    void SpawnBoss()
    {
        int numberOfSpawn = Random.Range(0, spawnPoints.Length);
        GameObject boss = Instantiate(bossPrefab, GetSpawnPoint(numberOfSpawn), GetSpawnDirection(numberOfSpawn));
        mobs.Add(boss);
    }

    public void RemoveMob(GameObject mob)
    {
        mobs.Remove(mob);
    }
}
