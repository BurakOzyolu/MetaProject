using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject door;
    [SerializeField] GameObject runDoor;
    [SerializeField] Transform playerSpawnPos;
    [SerializeField] GameObject friesPrefab;

    public int count;
    public bool canWin;
    public static bool canMove = true;
    public static int countWin = 5; 

    // Awake : Starttan once calisir. Genelde sahne baslatma ve referans alma islemleri icin kullanilir. 
    private void Awake()
    {
        PlayerSpawner(); // Playerimizi olusturduk.
    }
    private void Start()
    {
        FriesCouratineSpawnFries();  // Frieslarimizi olusturduk. 
    }

    // Instantiate : GameObject olusturmamizi saglar. Bizden 3 adet parametre ister. Bunlar sirasiyla olusturmak istedigimiz nesne, nesnenin olusturacagi pozisyon ve rotasyonu (yonu)
    // Quaternion.identity : Rotation degerlerini otomatik 0 ayarlayan kod.

    void PlayerSpawner() // Playeri spawnlayan metod.
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity); 
    }
    public void RespawnPlayer() // Playeri yeniden spawnlayan metod.
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
    }
    public void FriesSpawner() // Frieslari spawnlayan metod.
    {
        // Frieslarimizi oyun icerisinde rastgele yerlerde spawnlamak icin Rastgele x ve y degeri olusturan bir Vector3 olusturuyoruz.
        Vector3 spawnPos = new Vector3(Random.Range(-8.4f,8.4f),Random.Range(-4,0),0); 
        Instantiate(friesPrefab, spawnPos, Quaternion.identity);
    }
    //Frieslar�m�z� 1.5 saniye sonra olu�turulmas� sa�lar.
    public IEnumerator SpawnFries() 
    {
        if (count == countWin) //Count 5 e esit oldugunda oyun biter
        {
            canWin = true;
            door.SetActive(true); //Kap� nesnesi aktif olur.
            runDoor.SetActive(true); //Kapiya kosma yazisi aktif olur
            SoundManager.instance.RunDoorSound(); //Kapiya kosarken run door sound sesini calistirir.
        }
        //yield anahtar kelimesi bir d�ng� veya fonksiyon i�inde kullan�larak,
        //bir nesnenin �ye fonksiyonlar�n� �a��ran bir d�ng� veya fonksiyonun �al��mas�n� durdurur ve sonra tekrar ba�lat�lmas�na izin verir
        yield return new WaitForSeconds(1.5f);

        if (count < countWin) //Count 5 ten k�c�k oldugunda fries tekrar olustururlur.
        {
            FriesSpawner();
        }
    }
    public void FriesCouratineSpawnFries() //StartCoroutine metodunu kullanabilmek icin baska bir metod olusturup icine yazdik.
    {
        StartCoroutine(SpawnFries());
    }
}
