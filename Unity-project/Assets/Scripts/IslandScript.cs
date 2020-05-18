using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandScript : MonoBehaviour
{
    [SerializeField] private GameObject treasurePrefab;
    private float yPos = 4.4f;
    private int numberOfPrefabs = 60;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            GameObject temp = Instantiate(treasurePrefab, transform);
            float xPos = Random.Range(-80f, -100f);
            float zPos = Random.Range(-20f, -40f);
            temp.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }
}
