using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanagerscript : MonoBehaviour
{
    public GameObject enemyprefab;

    public GameObject enemycontainer;

    bool stopspawning = false;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {

    }

    public void OnPlayerDeath()
    {
        stopspawning = true;
    }

    IEnumerator SpawnRoutine()
    {
        while (stopspawning == false)
        {
            float x_pozisyon = Random.Range(-5, 5);
            Vector3 position = new Vector3(x_pozisyon, 6, 0);
            GameObject new_enemy = Instantiate(enemyprefab, position, Quaternion.identity);
            new_enemy.transform.parent = enemycontainer.transform;
            yield return new WaitForSeconds(5);
        }
    }
}
