using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Spawn Point")] 
    [SerializeField] private Transform spawnPoint;

    public Transform SpawnPoint => spawnPoint;
}
