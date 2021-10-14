using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float BounceForce;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        audioManager.Play("Bounce");
        playerRb.velocity = new Vector3(playerRb.velocity.x,BounceForce,playerRb.velocity.z);
        string materialName = other.transform.GetComponent<MeshRenderer>().material.name;
    
    if (materialName == "safe (Instance)")
    {

    }
    else if(materialName == "unsafe (Instance)")
    {
        theGameManager.gameOver = true;
        FindObjectOfType<AudioManager>().Play("GameOver");
    }
    else if(materialName == "LastRing (Instance)" && !theGameManager.levelComplete)
    {
        theGameManager.levelComplete = true;
        audioManager.Play("WInLevel");
    }
    }
}
