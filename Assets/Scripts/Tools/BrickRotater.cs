using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickRotater : MonoBehaviour {

    public int rotation;

    public OVRInput.Button rotate_ccw;
    public OVRInput.Button rotate_cw;

    public AudioClip rotate_sound;

    void Start() {
        
    }

    void FixedUpdate() {
        if (OVRInput.GetDown(rotate_ccw)) {
            rotation -= 90;
            SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, Quaternion.identity) as GameObject).GetComponent<SoundPlayer>();
            sp.playSound(rotate_sound);
        }
        if (OVRInput.GetDown(rotate_cw)) {
            rotation += 90;
            SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, Quaternion.identity) as GameObject).GetComponent<SoundPlayer>();
            sp.playSound(rotate_sound);
        }
    }
}
