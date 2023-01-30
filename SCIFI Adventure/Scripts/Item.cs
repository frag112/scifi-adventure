using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName ="New Item", menuName = "Item")]
public class Item : ScriptableObject
{
 [SerializeField] private string _name, description;
 [SerializeField] private Sprite _itemIcon;
 [SerializeField] private Item _itemCombineWith;

}
