using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries : MonoBehaviour
{
    private int friesValue;
    LevelManager levelManager;
    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
    }
    private void Start()
    {
        friesValue = Random.Range(1, 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Fries'in triggerina carpan(giren) seyin tagi "player" ise once fries'i yok et daha sonrasinda ise LevelManager scripti icerisindeki .FriesSpawner metodu ile yeni bir Fries spawnla(olustur) 
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.count++; //Her fries a dokunuldugunda count degeri artar.
            ScoreManager.instance.AddPoint(friesValue); //Bu fries deðeri score text'e eklenir.
            Destroy(gameObject);
            levelManager.FriesCouratineSpawnFries();
        }
    }
}
