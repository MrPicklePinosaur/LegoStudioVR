using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappableBrick : MonoBehaviour {

    public BrickGrid grid;
    public Quaternion rot;

    public bool isColliding;

    public Vector3 rot_offset;

    void Start() {
        
    }

    private void Update() {
        transform.position = grid.GetNearestPointOnGrid(transform.position);
        transform.rotation = rot;
        //Quaternion.Euler(new Vector3(rot_offset.x+rot.x,rot_offset.y+rot.y, rot_offset.z + rot.z));
    }

    void FixedUpdate() {


        isColliding = false;

        /*
        if (gameObject.layer == LayerMask.NameToLayer("BrickPreview")) {
            Collider[] hit = Physics.OverlapBox(GetComponent<BoxCollider>().center, transform.localScale / 2.1f, transform.rotation, LayerMask.NameToLayer("Bricks"));

        }
        */
    }


    /*
    private void OnTriggerStay(Collider other) {
        if (gameObject.layer == LayerMask.NameToLayer("BrickPreview") && other.gameObject.layer == LayerMask.NameToLayer("Bricks")) { //if a brick collides with another brick
            isColliding = true;
        }
    }
    

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position,transform.localScale);
    }
    */

}
