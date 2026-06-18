using UnityEngine;
using System.Collections.Generic;
public class DebugSpawner : MonoBehaviour
{
    public List<GameObject> enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            int selected = UnityEngine.Random.Range(1, enemies.Count);
            Instantiate(enemies[selected], gameObject.GetComponent<Transform>().position, Quaternion.identity);
        }
    }
}
