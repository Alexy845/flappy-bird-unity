using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTuyau : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject _pipe;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if( timer > maxTime )
        {
            SpawnPipe();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange), 0);
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }
}
