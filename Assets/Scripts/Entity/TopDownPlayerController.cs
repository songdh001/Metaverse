using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace TopDown
{
    public class PlayerController : BaseController
    {
        private Camera camera;

        private GameManager gameManager;

        public void Init(GameManager gameManager)
        {
            this.gameManager = gameManager;
            camera = Camera.main;
        }

        protected override void HandleAction()
        {





        }

        public override void Death()
        {
            base.Death();
            gameManager.GameOver();

        }

        void OnMove(InputValue inputValue)
        {
            //float horizontal = Input.GetAxisRaw("Horizontal");
            //float vertial = Input.GetAxisRaw("Vertical");
            //movementDirection = new Vector2(horizontal, vertial).normalized;

            movementDirection = inputValue.Get<Vector2>();
            movementDirection = movementDirection.normalized;
        }
        void OnLook(InputValue inputValue)
        {
            Vector2 mousePosition = inputValue.Get<Vector2>();
            Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
            lookDirection = (worldPos - (Vector2)transform.position);

            if (lookDirection.magnitude < 0.9f)
            {
                lookDirection = Vector2.zero;
            }
            else
            {
                lookDirection = lookDirection.normalized;
            }
        }

        void OnFire(InputValue inputValue)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //isAttacking = Input.GetMouseButton(0);
            isAttacking = inputValue.isPressed;
        }
    }

}
