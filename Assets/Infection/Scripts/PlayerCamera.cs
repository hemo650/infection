﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Infection
{
    [RequireComponent(typeof(Player))]
    public class PlayerCamera : NetworkBehaviour
    {
        private float verticalLook;
        private float horizontalLook;

        private void Update()
        {
            if (!isLocalPlayer) return;

            float lookY = Input.GetAxis("Look Y");
            float lookX = Input.GetAxis("Look X");

            verticalLook -= lookY;
            if (verticalLook > 90f) verticalLook = 90f;
            if (verticalLook < -90f) verticalLook = -90f;

            Vector3 currentAngles = GetComponent<Player>().camera.transform.localEulerAngles;
            currentAngles.x = verticalLook;
            // currentAngles.z = Vector3.Dot(characterController.velocity, -transform.right);

            GetComponent<Player>().camera.transform.localEulerAngles = currentAngles;

            horizontalLook += lookX;
            if (horizontalLook > 360) horizontalLook -= 360.0f;
            if (horizontalLook < 0) horizontalLook += 360.0f;

            currentAngles = transform.localEulerAngles;
            currentAngles.y = horizontalLook;

            transform.localEulerAngles = currentAngles;
        }
    }
}