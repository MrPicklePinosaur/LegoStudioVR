using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPicker : MonoBehaviour {

    public Color[] palette = new Color[10];

    private int current_index = 0;

    public Color getSelectedColour() { return palette[current_index];  }

    public OVRInput.Button next_colour;
    public OVRInput.Button prev_colour;

    public AudioClip cycle_sound;

    //wheel info
    public float orbit_radius;
    public float board_scale;

    private GameObject colour_wheel;

    void Start() {
        createWheel();
    }

    void FixedUpdate() {

        int new_index = current_index;

        if (OVRInput.GetDown(next_colour)) {
            new_index += 1;
            rotateWheelRight();
            SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, Quaternion.identity) as GameObject).GetComponent<SoundPlayer>();
            sp.playSound(cycle_sound);
        } 
        if (OVRInput.GetDown(prev_colour)) {
            new_index -= 1;
            rotateWheelLeft();
            SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"), transform.position, Quaternion.identity) as GameObject).GetComponent<SoundPlayer>();
            sp.playSound(cycle_sound);
        }

        
        if (new_index > palette.Length - 1) { new_index = 0; } 
        if (new_index < 0) { new_index = palette.Length - 1; }

        /*
        if (new_index != current_index) {
            current_index = new_index;
            GetComponent<HotBar>().updateSelectedBrick();
        }
        */
        

        //new_index = Mathf.Clamp(new_index,0,palette.Length-1);

        if (new_index != current_index) {
            current_index = new_index;
            //GetComponent<HotBar>().updateSelectedBrick();
            Color c = palette[current_index];
            Material m = Instantiate(Resources.Load("PlacePreview")) as Material;
            m.SetColor("_Color", new Color(c.r, c.g, c.b, 0.5f));
            GetComponent<BrickPlacerTool>().changePreviewMaterial(m);
        }  


    }

    private void createWheel() {

        colour_wheel = new GameObject();
        colour_wheel.transform.parent = GetComponent<BrickPlacerTool>().owner.transform;

        float angle = 2f * Mathf.PI / palette.Length;
        for (int i = 0; i < palette.Length; i++) {
            GameObject colour_board = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Material m = Instantiate(Resources.Load("PaletteColour")) as Material;
            m.color = palette[i];
            colour_board.GetComponent<MeshRenderer>().material = m;

            colour_board.transform.position = new Vector3(orbit_radius * Mathf.Cos(i * angle), orbit_radius * Mathf.Sin(i * angle), 0f);
            colour_board.transform.localScale = new Vector3(board_scale, board_scale, board_scale);
            colour_board.transform.rotation = Quaternion.Euler(colour_board.transform.rotation.x, colour_board.transform.rotation.y, i * angle * 180 / Mathf.PI + 90);
            colour_board.transform.parent = colour_wheel.transform;
        }
    }

    private void rotateWheelLeft() {
        colour_wheel.transform.Rotate(Vector3.back, -360 / palette.Length);
        /*
        colour_wheel.transform.Rotate(-360 / palette.Length, 0,0,0);
        Quaternion parent_rot = transform.parent.rotation;
        colour_wheel.transform.rotation = Quaternion.Euler(transform.rotation.x,parent_rot.y,parent_rot.z);
        */
        //colour_wheel.transform.localRotation = new Quaternion(- 360 / palette.Length,0,0,0);
    }
    private void rotateWheelRight() {
        colour_wheel.transform.Rotate(Vector3.back, 360 / palette.Length);
        /*
        colour_wheel.transform.Rotate(360 / palette.Length, 0,0,0);
        Quaternion parent_rot = transform.parent.rotation;
        colour_wheel.transform.rotation = Quaternion.Euler(transform.rotation.x, parent_rot.y, parent_rot.z);
        */
        //colour_wheel.transform.localRotation = new Quaternion(360 / palette.Length, 0, 0,0);
    }
}
