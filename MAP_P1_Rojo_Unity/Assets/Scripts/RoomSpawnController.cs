using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnController : MonoBehaviour
{
    SpawnComponent[] SpawnComponents;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Playermove playermove = collision.gameObject.GetComponent<Playermove>();

        if (playermove)
        {
            foreach (var SpawnComponent in SpawnComponents)
            {
                StartCoroutine(SpawnComponent.Spawn());
            }
        }
        // Dispara el método Spawn en el SpawnController de cada hijo de la sala (los spawners para cada objeto/enemigo)
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Dispara el método Despawn en el SpawnController de cada hijo de la sala (los spawners para cada objeto/enemigo)
        Playermove playermove = collision.gameObject.GetComponent<Playermove>();

        if (playermove)
        {
            foreach (var SpawnComponent in SpawnComponents)
            {
                SpawnComponent.Despawn();
            }
        }
    }

    void Start()
    {
        // Almacena todos los componentes "spawn" de los hijos de la sala (los spawners para cada objeto/enemigo)
        SpawnComponents = GetComponentsInChildren<SpawnComponent>();
    }
}
