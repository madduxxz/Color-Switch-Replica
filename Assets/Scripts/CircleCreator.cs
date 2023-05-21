using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CircleCreator : MonoBehaviour
{
    public GameObject[] colorCircles;

    public GameObject colorChanger;
    public static CircleCreator Instance {get; private set;}

    public Vector3 spawnPoint;
    public int index = 0;

    public int scores;
    
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    float yPos = 4.41f;
    
    void Awake()
    {
        if (Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    } 

    }
    public void Instantiate()
    {
        // int index = Random.Range(0,2);
        int spawnPosition = Random.Range(9, 11);
        yPos = yPos + spawnPosition;
        spawnPoint = new Vector3(gameObject.transform.position.x, yPos , gameObject.transform.position.z);
        Instantiate(colorCircles[index],spawnPoint, Quaternion.identity);
        // Instantiate(colorChanger,spawnPoint, Quaternion.identity);
        index++;
        if(index == 3)
        index = 0;
    }

    public void ScoreUpdate()
    {
        scores++;
        scoreText.text = scores.ToString();
    }

    public void AudioUpdate(int audioIndex)
    {
        audioSource.clip = audioClips[audioIndex];
        audioSource.Play();
    }
}
