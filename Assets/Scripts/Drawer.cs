using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour {
    public Camera cam;

    void Start() {
        cam = GetComponent<Camera>();
    }

    void Update() {
        if (!Input.GetMouseButton(0))
            return;

        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit)) {
            Debug.Log("Nada");
            return;
        }

        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if (rend == null) {
            Debug.Log("Nada 0");
            return;
        }

        if (rend.sharedMaterial == null) {
            Debug.Log("Nada 1");
            return;
        }
        if (rend.sharedMaterial.mainTexture == null) {
        Debug.Log("Nada 2");
        return;
        }
        if ( meshCollider == null) {
            Debug.Log("Nada 3");
            return;
        }

        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
        tex.Apply();
    }
}
