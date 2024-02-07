using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnController : MonoBehaviour
{
    SpawnComponent[] SpawnComponents;
    private void OnTriggerEnter(Collider other)
    {
        // Dispara el método Spawn en el SpawnController de cada hijo de la sala (los spawners para cada objeto/enemigo)
        foreach (var SpawnComponent in SpawnComponents)
        {
            SpawnComponent.Spawn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Dispara el método Despawn en el SpawnController de cada hijo de la sala (los spawners para cada objeto/enemigo)
        foreach (var SpawnComponent in SpawnComponents)
        {
            SpawnComponent.Despawn();
        }
    }

    void Start()
    {
        // Almacena todos los componentes "spawn" de los hijos de la sala (los spawners para cada objeto/enemigo)
        SpawnComponents = GetComponentsInChildren<SpawnComponent>();
    }
}
