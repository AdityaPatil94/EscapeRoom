
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdityaEscapeRoom
{
    public class InputHandler : MonoBehaviour
    {
        #region Data
        public InteractionInputData InputInteractionData;
        #endregion
        #region MovementInput
        public float xMovement;
        public float zMovement;
        public bool jumpPressed;
        #endregion

      
        // Update is called once per frame
        void Update()
        {
            GetInputInteractionData();
        }

        private void GetInputInteractionData()
        {
            InputInteractionData.InteractedClicked = Input.GetKeyDown(KeyCode.E);
            InputInteractionData.InteractedReleased = Input.GetKeyUp(KeyCode.E);
        }

        private void Movement()
        {
                xMovement = Input.GetAxis("Horizontal");
                zMovement = Input.GetAxis("Vertical");
                jumpPressed = Input.GetButtonDown("Jump");
        }
    }
}