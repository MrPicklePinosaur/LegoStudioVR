using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPlacerTool : MonoBehaviour {

    public BrickGrid grid;

    //PLACING
    private GameObject selected_brick;
    public GameObject owner;
    private GameObject preview;

    public OVRInput.Button placeButton;

    private Vector3 brick_pos;
    private Quaternion brick_rot;

    public AudioClip[] build_sounds;
    void Start() {


    }

    void Update() {

        brick_pos = grid.GetNearestPointOnGrid(owner.transform.position);
        brick_rot = Quaternion.Euler(new Vector3(-90f, GetComponent<BrickRotater>().rotation, 0f));
        preview.transform.position = brick_pos;
        preview.GetComponent<SnappableBrick>().rot = brick_rot;

        //if (OVRInput.GetDown(placeButton) && !preview.GetComponent<SnappableBrick>().isColliding) {
        if (OVRInput.GetDown(placeButton)) {
            GameObject new_brick = createCopy(); 
            new_brick.GetComponent<SnappableBrick>().rot = brick_rot;

            //Sound stuff
            SoundPlayer sp = (Instantiate(Resources.Load("SoundPlayer"),transform.position,Quaternion.identity) as GameObject).GetComponent<SoundPlayer>();
            sp.playRandomSound(build_sounds);
        }

    }

    public GameObject createCopy() {
        GameObject b = Instantiate(selected_brick, brick_pos, brick_rot) as GameObject;
        b.GetComponent<MeshRenderer>().material.color = GetComponent<ColourPicker>().getSelectedColour();
        return b;
    }

    public void setSelectedBrick(GameObject brick) {

        selected_brick = brick;

        GameObject old = preview;
        preview = createCopy();
        preview.layer = LayerMask.NameToLayer("BrickPreview");
        if (old != null) { Destroy(old); }


        //Make preview colour slightly transparent
        Color c = preview.GetComponent<MeshRenderer>().material.color;
        /* Color c = new Color(0.8f,0.8f,0.8f,0.5f);
        if (!brick.GetComponent<SnappableBrick>().isColliding) { c = preview.GetComponent<MeshRenderer>().material.color; }
        */

        Material m = Instantiate(Resources.Load("PlacePreview")) as Material;
        m.SetColor("_Color", new Color(c.r, c.g, c.b, 0.5f));
        changePreviewMaterial(m);
        
    }

    public void changePreviewMaterial(Material m) {
        preview.GetComponent<MeshRenderer>().material = m;
    }


}
