using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Ses Kaynaklarini atamak icin gerekli degiskenleri olusturduk.
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landSound;
    [SerializeField] AudioClip deadByEnemySound;
    [SerializeField] AudioClip deadByFallSound;
    [SerializeField] AudioClip attackEnemySound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip runDoorSound;

    public static SoundManager instance;
    //Singleton Design Pattern ile bu class'ýn nesnesini static olarak oluþturuyoruz. 
    //instance referansi ile bu class'ýn metodlarýna ulaþabiliriz.
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else 
        { 
            instance = this; 
        }   
        
    }
    // Sesleri calistabilmek icin bir ses kaynagi lazim bundan dolayi Start metodu icerisinde gerekli olan audioSource'u cektik.
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // audioSource.PlayOneShot metodu(parametre); PlayOneShot metodu parametre olarak verilen sesi bir kez calmasini saglar. 

    // Ziplama Sesi
    public void JumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
        Debug.Log("Jumped");
    }

    // Zemin Sesi
    public void LandSoundSound()
    {
        audioSource.PlayOneShot(landSound);
        Debug.Log("Land");
    }

    // Dusman tarafindan olme sesi
    public void DeadByEnemySound()
    {
        audioSource.PlayOneShot(deadByEnemySound);
        Debug.Log("Dead by Enemy");
    }

    // Asagiya duserek olme sesi
    public void DeadByFallSound()
    {
        audioSource.PlayOneShot(deadByFallSound);
        Debug.Log("Dead by Fall");
    }

    // Enemylerin saldiri sesi
    public void AttackEnemySound()
    {
        audioSource.PlayOneShot(attackEnemySound);
        Debug.Log("Enemy Attacked");
    }
    //Kazanma sesi
    public void WinSound()
    {
        audioSource.PlayOneShot(winSound);
        Debug.Log("Win Sound");
    }

    public void RunDoorSound()
    {
        audioSource.PlayOneShot(runDoorSound);
        Debug.Log("Run Door Sound");

    }
}
