using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class FollowCamera : MonoBehaviour
    {
    [Title("Camera")]
    public Camera camera;
    private void Awake()
    {
        camera = Camera.main;
        }
    

    //private void OnWillRenderObject()
    //{
    //    transform.LookAt(camera.transform);
    //}
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera.transform);
        transform.Rotate(180, 0, 180);
        }
}
