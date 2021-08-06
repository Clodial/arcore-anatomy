using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    int scalingFramesLeft = 0;
    bool isFocus = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFocus) {
            if (scalingFramesLeft > 0) {
                Vector3 startingPos = this.transform.localScale;
                Vector3 newPos = startingPos + new Vector3(0.1f, 0.1f, 0.1f);
                this.transform.localScale = Vector3.Lerp (startingPos, newPos, Time.deltaTime * 10);
                scalingFramesLeft--;
            }
        }
        else {
            if (scalingFramesLeft > 0) {
                Vector3 startingPos = this.transform.localScale;
                Vector3 newPos = startingPos + new Vector3(-0.1f, -0.1f, -0.1f);
                this.transform.localScale = Vector3.Lerp (startingPos, newPos, Time.deltaTime * 10);
                scalingFramesLeft--;
            }
        }
        
    }

    public void grow() {
        scalingFramesLeft = 60;
        isFocus = true;
    }

    public void shrink() {
        scalingFramesLeft = 60;
        isFocus = false;
    }

}
