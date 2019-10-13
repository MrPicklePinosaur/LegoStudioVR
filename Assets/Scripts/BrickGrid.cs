using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGrid : MonoBehaviour {

    public float grid_cell_width;
    public float grid_cell_height;

    public float grid_length;
    public float grid_width;
    public float grid_height;

    public float gizmo_radius = 0.07f;

    void Start() {
        
    }

    void Update() {
        
    }


    public Vector3 GetNearestPointOnGrid(Vector3 pos) {

        pos -= transform.position; //get offset

        int grid_x = Mathf.RoundToInt(pos.x / grid_cell_width);
        int grid_y = Mathf.RoundToInt(pos.y / grid_cell_height);
        int grid_z = Mathf.RoundToInt(pos.z / grid_cell_width);

        Vector3 resultant = new Vector3(
            (float) grid_x*grid_cell_width,
            (float) grid_y * grid_cell_height,
            (float) grid_z * grid_cell_width
            );

        resultant += transform.position;

        return resultant;

    }

    /*
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;

        for (float x = 0; x < grid_length; x++) {
            for (float y = 0; y < grid_height; y++) {
                for (float z = 0; z < grid_width; z++) {
                    Vector3 pos = transform.position;
                    Vector3 point = GetNearestPointOnGrid(new Vector3(x * grid_cell_width, y * grid_cell_width, z * grid_cell_width));
                    Gizmos.DrawSphere(new Vector3(point.x+pos.x,point.y+pos.y,point.z+pos.z), gizmo_radius);
                }
            }
        }
    }
    */
    

}
