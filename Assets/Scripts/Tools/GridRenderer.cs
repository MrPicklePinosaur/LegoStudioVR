using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRenderer : MonoBehaviour {

    public BrickGrid grid;
    public GameObject target;
    public int grid_width;
    public float grid_sphere_scale;


    void Start() {
        DrawGrid();
    }

    void Update() {
        Vector3 t_pos = target.transform.position;
        transform.position = grid.GetNearestPointOnGrid(new Vector3(
                t_pos.x - grid_width * grid.grid_cell_width/2.5f,
                t_pos.y - grid_width * grid.grid_cell_height / 2.5f,
                t_pos.z - grid_width * grid.grid_cell_width / 2.5f
            ));
    }

    public void DrawGrid() {
        for (int x = 0; x < grid_width; x++) {
            for (int y = 0; y < grid_width; y++) {
                for (int z = 0; z < grid_width; z++) {
                    GameObject s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Vector3 true_pos = new Vector3(
                        x * grid.grid_cell_width,
                        y * grid.grid_cell_height * 3,  //times 3 cuz we dont wanna see the plate grid
                        z * grid.grid_cell_width
                        );

                    Vector3 center = new Vector3(grid_width * grid.grid_cell_width / 2f, grid_width * grid.grid_cell_height / 2f,grid_width * grid.grid_cell_width / 2f);
                    float opacity_percent = ( //the further the object from the center of the cube, the less opaque it is
                            Vector3.Distance(true_pos/2, center) /
                            Vector3.Distance(center*2, new Vector3(0, 0, 0))
                        );

                    Material m = Instantiate(Resources.Load("GridSphere")) as Material;
                    m.SetColor("_Color", new Color(1f,1f,1f,1-opacity_percent));

                    s.transform.position = grid.GetNearestPointOnGrid(true_pos);
                    s.transform.localScale = new Vector3(grid_sphere_scale, grid_sphere_scale, grid_sphere_scale);
                    s.transform.parent = transform; //make spheres the children of this object\
                    //Debug.LogError(m.color.a);
                    s.GetComponent<MeshRenderer>().material = m;

                }
            }
        }
    }
}
