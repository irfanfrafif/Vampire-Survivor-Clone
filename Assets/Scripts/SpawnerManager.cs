using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] Transform enemyPool; // Not an actual object pool, just naming it this way to organize the hierarchy
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<Transform> transforms;
    [SerializeField] float spawnInterval;

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    private void Update()
    {
        transform.position = GameManager.Instance.player.transform.position;
    }

    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(spawnInterval);

        while(true)
        {
            int index = Random.Range(0, 8);
            Instantiate(enemyPrefab, transforms[index].position, Quaternion.identity, enemyPool);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
