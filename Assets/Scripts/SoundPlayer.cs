using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    private AudioSource audio_source;

    private bool sound_started;

    void Awake() {
        audio_source = GetComponent<AudioSource>();

    }

    void Update() {

        if (!audio_source.isPlaying && sound_started) {
            Destroy(this.gameObject);
        }
    }

    public void playSound(AudioClip sound) {
        audio_source.clip = sound;
        audio_source.Play();
        sound_started = true;
    }

    public void playRandomSound(AudioClip[] sounds) {
        int index = Random.Range(0,sounds.Length-1);
        playSound(sounds[index]);
    }
}