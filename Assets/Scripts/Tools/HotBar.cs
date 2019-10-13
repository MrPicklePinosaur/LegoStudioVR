using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBar : MonoBehaviour {

    public GameObject[] hotbar_items = new GameObject[10];
    //public GameObject[,] brick_box = new GameObject[10,10];

    public GameObject getSelectedBrick() { return hotbar_items[current_index]; }

    [SerializeField] private int current_index;

    public OVRInput.Button cycle_left;
    public OVRInput.Button cycle_right;
    public OVRInput.Button cycle_up;
    public OVRInput.Button cycle_down;

    public AudioClip cycle_left_sound;
    public AudioClip cycle_right_sound;

    void Start() {
        updateSelectedBrick();
    }

    void Update() {
        int new_index = current_index;

        if (OVRInput.GetDown(cycle_right)) {
            new_index += 1;
            SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, Quaternion.identity) as GameObject).GetComponent<SoundPlayer>();
            sp.playSound(cycle_right_sound);
        }
        if (OVRInput.GetDown(cycle_left)) {
            new_index -= 1;
            SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, Quaternion.identity) as GameObject).GetComponent<SoundPlayer>();
            sp.playSound(cycle_left_sound);
        }

        if (new_index > hotbar_items.Length-1) { new_index = 0;} 
        if (new_index < 0) { new_index = hotbar_items.Length-1; }

        if (new_index != current_index) { //if an update was performed
            current_index = new_index;
            updateSelectedBrick();
        }
    }

    public void updateSelectedBrick() {
        BrickPlacerTool bpt = gameObject.GetComponent<BrickPlacerTool>();
        bpt.setSelectedBrick(getSelectedBrick());
    }
}
