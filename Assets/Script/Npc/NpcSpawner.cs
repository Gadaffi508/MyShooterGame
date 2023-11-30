using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NpcSpawner : MonoBehaviour
{
    public GameObject[] NpcObjs;
    public Transform StartPos;

    private void Start() => SpawnNpc();

    public void SpawnNpc()
    {
        int random = Random.Range(0, NpcObjs.Length);
        Instantiate(NpcObjs[random], StartPos.position, StartPos.rotation);
    }
}
