using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    public bool X_lock = false;
    public bool Y_lock = false;
    public bool Z_lock = false;
    private float x_val, y_val, z_val;
    private Vector3 eulerAngles;

    void Start()
    {
        eulerAngles = transform.eulerAngles;

        if (X_lock)
        {
            x_val = eulerAngles.x;
        }
        if (Y_lock)
        {
            y_val = eulerAngles.y;
        }
        if (Z_lock)
        {
            z_val = eulerAngles.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        eulerAngles = transform.eulerAngles;

        if (X_lock)
        {
            if (Y_lock)
            {
                if (Z_lock)
                {
                    transform.eulerAngles = new Vector3(x_val, y_val, z_val);
                }
                else
                {
                    transform.eulerAngles = new Vector3(x_val, y_val, eulerAngles.z);
                }
            }
            else
            {
                if (Z_lock)
                {
                    transform.eulerAngles = new Vector3(x_val, eulerAngles.y, z_val);
                }
                else
                {
                    transform.eulerAngles = new Vector3(x_val, eulerAngles.y, eulerAngles.z);
                }
            }
        }
        else
        {
            if (Y_lock)
            {
                if (Z_lock)
                {
                    transform.eulerAngles = new Vector3(eulerAngles.x, y_val, z_val);
                }
                else
                {
                    transform.eulerAngles = new Vector3(eulerAngles.x, y_val, eulerAngles.z);
                }
            }
            else
            {
                if (Z_lock)
                {
                    transform.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, z_val);
                }
                else
                {
                    transform.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, eulerAngles.z);
                }
            }
        }
    }
}
