using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mobPrefab;
    public List<GameObject> mobs;
    public float delieBetweenWaves = 3f;
    public int currentWave = 1;
    public GameObject[] spawnPoints;
    public Vector3 mobLook;

    public bool waitForMobs = true;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        mobs.Clear();
        int mobsCount = currentWave * 3;
        for (int i = 0; i < mobsCount; i++)
        {
            
            int numberOfSpawn = Random.Range(0, spawnPoints.Length);
            yield return new WaitForSeconds(1);
            GameObject m = Instantiate(mobPrefab, GetSpawnPoint(numberOfSpawn), GetSpawnDirection(numberOfSpawn));
            mobs.Add(m);
        }
        waitForMobs = false;
    }

    private void Update()
    {
        if (waitForMobs) return;

        if (mobs.Count == 0)
        {
            currentWave++;
            waitForMobs = true;
            StartCoroutine(NextWave());
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

    public void RemoveMob(GameObject mob)
    {
        mobs.Remove(mob);
    }
}
