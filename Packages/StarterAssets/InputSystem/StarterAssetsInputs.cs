using ScifiAdventure;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;

#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		//[Header("Character Input Values")]
		[HideInInspector] public Vector2 move;
		[HideInInspector] public Vector2 look;

		[HideInInspector]public bool sprint;
		private bool inventory, interaction, questList, isPaused;
		private PlayerInput _playerInput;

		//[Header("Movement Settings")]
		[HideInInspector]public bool analogMovement;

		//[Header("Mouse Cursor Settings")]
		[HideInInspector]public bool cursorLocked = true;
		[HideInInspector]public bool cursorInputForLook = true;

		[Header("UI Inputs")]
		public bool pause, submit;

        private Interactible _currentInteractible;

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
        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }

        public void OnInteraction(InputValue value)
		{
            if (!_currentInteractible)
            {
                return;
            }
            _currentInteractible.Interact();
        }
		public void OnShowActiveQuests()
		{
            UIHandler.Instance.ShowActiveQuests();
		}

		public void OnInventory(InputValue value)
		{
            SwitchActionControl("UI Navigation");
			UIHandler.Instance.ShowInventory();
        }


        public void OnPause()
        {
			if (!isPaused)
			{
				Time.timeScale = 0f;
                SwitchActionControl("UI Navigation");
				UIHandler.Instance.ShowHidePauseMenu();
				isPaused= true;
			}
			else
			{
				Time.timeScale = 1f;
				UIHandler.Instance.ShowHidePauseMenu();
				isPaused= false;
                SwitchActionControl("Player");
			}
        }
		public void OnSubmit(InputValue value)// кнопка подтверждения в ui navigation схеме, пока ничего не делает, но нужна для использования предмета
		{
		
			//Debug.Log("i am sumiy");
		}
		public void OnCancel()  // выйти из инвентаря при вкл инвентаре
		{
            var currentActionMap = _playerInput.currentActionMap.name;
            if (_playerInput.currentActionMap.name == "UI Navigation")
            {
                UIHandler.Instance.HideInventory();
				SwitchActionControl("Player");
            }
        }
        public void OnNextDialogue()  // если вкл кправление в дилогах то перейти на след линию
        {
			var currentActionMap = _playerInput.currentActionMap.name;
            if(_playerInput.currentActionMap.name == "Dialogue Navigation")
			{
				UIHandler.Instance.ContinueDialogue();
			}
        }
		public void OnSkipDialogue()  // если включено управление в диалогах скипнуть диалог
		{
            if (_playerInput.currentActionMap.name == "Dialogue Navigation")
            {
                UIHandler.Instance.SkipDialogue();
            }
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
			//Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}


        public void AssignInteractibe(Interactible newInteractible) // вписывает активный интерактибл в поле. Его метод interact будет вызываться при нажатии на кнопочку
        {
            _currentInteractible = newInteractible;
		}
        public void SwitchActionControl(string schemeName) // переключает набор управления по имени
        {
            _playerInput.SwitchCurrentActionMap(schemeName);
        }
        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
        }
    }
	
}