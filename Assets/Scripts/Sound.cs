using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource AudioSrcMenu;
    public AudioSource AudioSrcGame;
    // Start is called before the first frame update
    void Start()
    {
        AudioSrcMenu = this.gameObject.AddComponent<AudioSource>();
        AudioSrcMenu.clip = Resources.Load<AudioClip>("Sounds/MenuScreen");
        AudioSrcMenu.loop = true;
        AudioSrcGame = this.gameObject.AddComponent<AudioSource>();
        AudioSrcGame.clip = Resources.Load<AudioClip>("Sounds/MainTheme1");
        AudioSrcGame.loop = true;
    }

    void PlayBackgroundMusic() { 
         if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name == "Game") {
            AudioSrcGame.Play();
        } else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name == "Scene2") {
            AudioSrcMenu.Play();
        } 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
