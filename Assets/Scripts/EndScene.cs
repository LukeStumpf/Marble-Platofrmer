using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour {

	private void Update ()
    {
        if (Input.anyKeyDown)
        {
            Application.Quit();
            Debug.Log("Any key pressed");
        }
    }
}
