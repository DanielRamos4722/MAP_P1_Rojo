using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ÑapaManager : MonoBehaviour
{
    [SerializeField] GameObject[] pulpos = new GameObject[4];

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < pulpos.Length; i++)
        {
            if (!pulpos[i].activeSelf)
                pulpos[i].SetActive(true);
            else
                pulpos[i].SetActive(false);
        }
    }
}
