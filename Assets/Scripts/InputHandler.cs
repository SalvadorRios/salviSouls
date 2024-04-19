using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace SG 
{
    public class InputHandler : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;
        public bool b_Input;
        public bool s_Input;
        public bool rollFlag;

        public float rollInputTimer;
        public bool sprintFlag;

        PlayerControls inputActions;

        Vector2 movmentInput;
        Vector2 cameraInput;



        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();
                inputActions.PlayerMovment.Movment.performed += inputActions => movmentInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovment.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            }
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void TickInput(float delta)
        {
            MoveInput(delta);
            HandleRollInput(delta);
        }

        private void MoveInput(float delta)
        {
            horizontal = movmentInput.x;
            vertical = movmentInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }

        private void HandleRollInput(float delta)
        {

            b_Input = inputActions.PlayerActions.Roll.IsPressed();
            if (b_Input)
            {
                rollFlag = true;
            }

            s_Input = inputActions.PlayerActions.Sprint.IsPressed();
            if (s_Input)
            {
                rollInputTimer += delta;
                sprintFlag = true;
            }
            else
            {
                if (rollInputTimer > 0 && rollInputTimer < 0.5f)
                {
                    sprintFlag = false;
                }
                rollInputTimer = 0;
            }
        }
    }

}

