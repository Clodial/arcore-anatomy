using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{

    // int scalingFramesLeft = 0;
    GameObject go;   
    public Interactable focus;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        // If Left mouse clicked
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100.0f)) {
                if(hit.transform != null) {
                    go = hit.transform.gameObject;
                    PrintName(go);
                    // scalingFramesLeft = 60;
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    // If we hit an interactable, set as focu
                    if(interactable != null) {
                        SetFocus(interactable);
                    }
                }
            }
            else {
                RemoveFocus();
            }
        }

        // if (scalingFramesLeft > 0) {
        //     Vector3 startingPos = go.transform.localScale;
        //     Vector3 newPos = startingPos + new Vector3(0.1f, 0.1f, 0.1f);
        //     go.transform.localScale = Vector3.Lerp (startingPos, newPos, Time.deltaTime * 10);
        //     scalingFramesLeft--;
        // }
        
    }

    private void PrintName(GameObject go) {
        print(go.name);
    }

    void SetFocus(Interactable newFocus){
        if(newFocus != focus) {
            if(focus != null) {
                RemoveFocus();
            }
            focus = newFocus;
            newFocus.grow();
        }      
    }

    void RemoveFocus() {
        focus.shrink();
        focus = null;
    }
}
