using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GyroControl : MonoBehaviour
{
    public TextMeshProUGUI gyroText;
    public TextMeshProUGUI accelerometerText;
    public GameObject gyroCube;
    public GameObject accelerometerCube;
    public float scaleFactor;

    private bool gyroEnabled;
    private Gyroscope gyro;    

    // Start is called before the first frame update
    void Start()
    {
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }

    private void Update()
    {
        gyroText.text = "Gyro: " + gyro.attitude.ToString();
        gyroCube.transform.position = new Vector3(gyro.attitude.x * scaleFactor, gyro.attitude.y * scaleFactor, gyroCube.transform.position.z);

        accelerometerText.text = "Accel: " + Input.acceleration.ToString();
        accelerometerCube.transform.position = new Vector3(Input.acceleration.x * scaleFactor, Input.acceleration.y * scaleFactor, accelerometerCube.transform.position.z);
    }
}
