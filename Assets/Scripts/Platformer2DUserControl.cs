using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Shoot;
        private float m_Moov = 0;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if (m_Moov == 0) {
               if (Input.anyKey || (Input.touchCount == 1)) {
                m_Moov = 1;
                PlayerPrefs.SetInt("Score", 0);
               }
            }

            if (!m_Jump) {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetButtonDown("Jump") || (Input.touchCount == 1 && (Input.GetTouch(0).position.x > Screen.width/3) && (Input.GetTouch(0).phase == TouchPhase.Began));
            }

            if (!m_Shoot) {
                m_Shoot = Input.GetButtonDown("Fire1") || (Input.touchCount == 1 && (Input.GetTouch(0).position.x < Screen.width/3) && (Input.GetTouch(0).phase == TouchPhase.Began));
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(m_Moov, false, m_Jump, m_Shoot);
            m_Jump = false;
            m_Shoot = false;
        }
    }
}
