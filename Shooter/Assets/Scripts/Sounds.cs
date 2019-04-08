﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static new AudioSource audio;
    public static AudioClip laser;
    public static AudioClip explosion;
    public static AudioClip hit;

    public AudioSource music;

    public static float sfxvol;
    public static float musicvol;

    private void Awake()
    {
        sfxvol = PlayerPrefs.GetFloat("SFX Volume", 20);
        musicvol = PlayerPrefs.GetFloat("Music Volume", 20);

    }
    private void Start()
    {
        laser = Resources.Load<AudioClip>("Laser_Shoot36");
        explosion = Resources.Load<AudioClip>("Explosion41");
        hit = Resources.Load<AudioClip>("Pickup_Coin");

        music.volume = musicvol;

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void play_sound(string clip)
    {
        if (clip == "Laser_Shoot36")
        {
            audio.PlayOneShot(laser, sfxvol);
        }
        if (clip == "Explosion41")
        {
            audio.PlayOneShot(explosion, sfxvol);
        }
        if (clip == "Pickup_Coin")
        {
            audio.PlayOneShot(hit, sfxvol);
        }
    }
}
