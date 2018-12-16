using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] private GameObject distraction;

    // Update is called once per frame
    void Update ()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 4.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 4.0f;

        //transform.Rotate(0, x, 0);
        transform.Translate(z, 0, x);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                distraction.gameObject.SetActive(true);
                distraction.transform.position = hit.point;
            }
        }
    }
}
