using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    static GameObject myself;
    Transform myTransform;

    [SerializeField]
    string name;

    void Start()
    {
        // Asigna variables
        myself = gameObject;
        myTransform = transform;
    }
    public void Spawn()
    {
        // Usando la variable name, cargar un prefab en la propia posición del objeto con el nombre "name" (myTransform)
        //yield return new WaitForSeconds(1);
        Instantiate(Resources.Load<GameObject>(name), myTransform.position, Quaternion.identity, myTransform);
        print("va");
        // IMPORTANTE: Cuando se cargue el prefab, ponerlo como hijo del propio spawner (para encontrarlo en Despawn)
    }

    public void Despawn()
    {
        // Destruye todos los hijos del spawner (será uno, pero está puesto como todos por si acaso)
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
}