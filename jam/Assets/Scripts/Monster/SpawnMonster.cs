using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject[] monsterPrefabs;
    public float spawnInterval = 4f;
    public float spawnAreaX = 20f;
    public float spawnAreaY = 10f;
    public float spawnAreaZ = 20f;
    public int maxMonsters = 20;

    private int currentMonsterCount = 0;

    void Start()
    {
        InvokeRepeating("SpawnObject", 4f, spawnInterval);
    }

    void SpawnObject()
    {
        if (currentMonsterCount < maxMonsters) {
            GameObject randomMonsterPrefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];
            Vector3 randomSpawnPoint = new Vector3(
                transform.position.x + Random.Range(-spawnAreaX / 2, spawnAreaX / 2),
                transform.position.y + Random.Range(-spawnAreaY / 2, spawnAreaY / 2),
                transform.position.z + Random.Range(-spawnAreaZ / 2, spawnAreaZ / 2)
            );

            GameObject monster = Instantiate(randomMonsterPrefab, randomSpawnPoint, Quaternion.identity);
            monster.AddComponent<FaceCamera>();

            currentMonsterCount++;
        }
        else {
            CancelInvoke("SpawnObject");
        }
    }
}
