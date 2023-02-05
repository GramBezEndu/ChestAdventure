using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objects;

    [SerializeField]
    private GameObject replacementPrefab;

    private void Awake()
    {
        int randomIndex = Random.Range(0, objects.Length);
        for (int i = 0; i < objects.Length; i++)
        {
            if (i == randomIndex)
            {
                objects[i].SetActive(true);
            }
            else
            {
                objects[i].SetActive(false);
                if (replacementPrefab != null)
                {
                    Instantiate(replacementPrefab, objects[i].transform.position, objects[i].transform.rotation);
                }
            }
        }
    }
}
