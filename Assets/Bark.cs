using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public AudioClip[] barks;
    private AudioSource _audio;
    
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void barkFunction()
    {
        var barkSelected = Random.Range(0, barks.Length);

        _audio.clip = barks[barkSelected];
        _audio.Play();
    }
}
