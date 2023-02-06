using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objects;

    [SerializeField]
    private GameObject objectPrefab;

    [SerializeField]
    private GameObject replacementPrefab;

    private int drawnIndex;

    private GameObject[] replacements;

    public void Generate()
    {
        drawnIndex = Random.Range(0, objects.Length);
        for (int i = 0; i < objects.Length; i++)
        {
            if (i == drawnIndex)
            {
                objects[i].SetActive(true);
                if (replacements[i] != null)
                {
                    Destroy(replacements[i]);
                }
            }
            else
            {
                objects[i].SetActive(false);
                if (replacementPrefab != null)
                {
                    if (replacements[i] == null)
                    {
                        replacements[i] = 
                            Instantiate(replacementPrefab, objects[i].transform.position, objects[i].transform.rotation);
                    }
                }
            }
        }
    }

    public void Restore()
    {
        RestoreUsedObject();
        HandleReplacementPrefabs();

        void RestoreUsedObject()
        {
            GameObject usedObject = objects[drawnIndex];
            Vector3 position = usedObject.transform.position;
            Quaternion rotation = usedObject.transform.rotation;
            Destroy(usedObject);
            objects[drawnIndex] = Instantiate(objectPrefab, position, rotation);
            objects[drawnIndex].SetActive(false);
        }

        void HandleReplacementPrefabs()
        {

        }
    }

    private void Awake()
    {
        replacements = new GameObject[objects.Length];
        Generate();
    }
}
