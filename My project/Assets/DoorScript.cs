using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject runDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            winPanel.SetActive(true);
            runDoor.SetActive(false);
            LevelManager.canMove = false;
            SoundManager.instance.WinSound();
        }
    }
}
