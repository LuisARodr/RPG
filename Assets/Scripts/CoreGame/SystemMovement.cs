﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.SystemControls;

namespace GameCore
{
    namespace SystemMovements
    {
        public class Movement 
        {
            public static Vector2 AxisDeltaTime
            {
                get
                {
                    return Controllers.GetJoystick(1,1) * Time.deltaTime;
                }
            }

            public static void MoveForward(Rigidbody rb, float speed, Transform t)
            {
                rb.velocity = t.forward * speed * AxisDeltaTime.y;
            }
            
        
            public static void JumpUp(Rigidbody rb, float jumpForce)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }


            public static float rotation = 0f;

            public static void RotateY(Transform t, float rotationSpeed)
            {
                rotation += Controllers.GetJoystick(1, 1).x * rotationSpeed;

                t.rotation = Quaternion.Euler(0f, rotation, 0f);
            }
            
        }
    }
}