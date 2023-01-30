using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;

		public bool inventory;
		public bool interaction;
		public bool sprint;
		public bool _fuck;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}
<<<<<<< HEAD
			public void OnJump(InputValue value)
=======

		public void OnInteraction(InputValue value)
>>>>>>> remotes/origin/dev2
		{
			InteractionInput(value.isPressed);
		}

		public void OnInventory(InputValue value)
		{
			InventoryInput(value.isPressed);
		}
		public void OnFuck(InputValue value)
		{
			FuckInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void InventoryInput(bool newInventoryState)
		{
			inventory = newInventoryState;
		}

		public void InteractionInput(bool newInteractionState)
		{
			interaction = newInteractionState;
		}
		public void FuckInput(bool newFuckState)
		{
			_fuck= newFuckState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}