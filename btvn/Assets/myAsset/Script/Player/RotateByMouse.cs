using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    public float anglePerSecond;
    public Transform cameraHolder;
    public float minPitch;
    public float maxPitch;

    private float pitch;
    // Start is called before the first frame update
    private void Update()
    {
        UpdateYaw();
        updatePitch();
    }
    // Update is called once per frame
    void UpdateYaw()
    {
        float mouseX=Input.GetAxis("Mouse X");
        float yaw=mouseX*anglePerSecond*Time.deltaTime*2;
        transform.Rotate(0, yaw, 0);
    }
    void updatePitch()
    {
        float mouseY=Input.GetAxis("Mouse Y");
        float detailPeach=-mouseY*anglePerSecond;
        pitch=Mathf.Clamp(pitch + detailPeach,minPitch,maxPitch);
        cameraHolder.localEulerAngles=new Vector3(pitch,0,0);
    }
}
