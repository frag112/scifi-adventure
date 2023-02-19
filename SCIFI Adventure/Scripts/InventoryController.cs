using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class InventoryController : MonoBehaviour
    {
        public static InventoryController Instance;
        [SerializeField] private Player _player;
        private void Awake() // пока что здесь ничего не происходит, только вот эта проверка на синглтон
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }


    }
}