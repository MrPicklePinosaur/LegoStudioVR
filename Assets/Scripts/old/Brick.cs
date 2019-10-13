using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    [SerializeField] private Quaternion rot;
    [SerializeField] private Color colour;

    void Start() {
        GetComponent<MeshRenderer>().material.color = new Color(0.8f, 0.8f, 0.8f, 0.5f);
    }

    void Update() {
        
    }

    /*
    public GameObject duplicate() { //creates a permenant duplicate of this preview
        GameObject new_brick = Instantiate(gameObject,transform.position,transform.rotation) as GameObject;
        return new_brick;
    }
    */

    public Vector3 getTranform() { return transform.position; }
    public Quaternion getRotation() { return rot; }
    public Color getColor() { return colour; }
    public void setYRotation(float y) { rot = Quaternion.Euler(new Vector3(-90f, y, 0f)); }
    public void setColourAndAlpha(Color new_colour) {
        GetComponent<MeshRenderer>().material.color = new_colour;
    }
    public void setColour(Color new_colour) {
        GetComponent<MeshRenderer>().material.color = new Color(new_colour.r, new_colour.g, new_colour.b, this.colour.a);
    }

    public void snapToGrid(Vector3 snapped_pos) { transform.position = snapped_pos; }
}
