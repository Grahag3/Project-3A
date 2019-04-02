using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Volume : MonoBehaviour
{

    public Slider music;
    public Slider effects;

    private AudioSource sounds;



    // Start is called before the first frame update

    private void Awake()
    {



    }

    void Start()
    {
        Sounds.sfxvol = effects.value;



        sounds = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();


        music.value = PlayerPrefs.GetFloat("MusicVol");

        if (PlayerPrefs.GetFloat("MusicVol") == 0)
        {
            music.value = sounds.volume;
        }

        effects.value = PlayerPrefs.GetFloat("EffectsVol");

        if (PlayerPrefs.GetFloat("EffectsVol") == 0)
        {
            effects.value = Sounds.sfxvol;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MusicVolume()
    {
        //sounds.volume = music.value;
        PlayerPrefs.SetFloat("MusicVol", sounds.volume);
    }

    public void SFXVolume()
    {
        Sounds.sfxvol = effects.value;
        PlayerPrefs.SetFloat("EffectsVol", Sounds.sfxvol);
    }
}