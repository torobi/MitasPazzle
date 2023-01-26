using System.Collections.Generic;
using Adapter;
using Adapter.Controller;
using Adapter.DTO;
using UnityEngine;

public class KeyboardView : MonoBehaviour
{
    private readonly KeyboardController _keyboardController = new();
    private readonly Dictionary<KeyCode, Keyboard.Key> _keyTable = new();
    
    private void Awake()
    {
        DefKeyTable();
    }

    private void DefKeyTable()
    {
        _keyTable[KeyCode.LeftArrow]  = Keyboard.Key.MoveLeft;
        _keyTable[KeyCode.RightArrow] = Keyboard.Key.MoveRight;
        _keyTable[KeyCode.A]          = Keyboard.Key.TurnLeft;
        _keyTable[KeyCode.D]          = Keyboard.Key.TurnRight;
        _keyTable[KeyCode.DownArrow]  = Keyboard.Key.Drop;
        _keyTable[KeyCode.UpArrow]    = Keyboard.Key.HardDrop;
        _keyTable[KeyCode.W]          = Keyboard.Key.Keep;
        _keyTable[KeyCode.S]          = Keyboard.Key.Trash;
        
    }
    
    void Update()
    {
        var isDown = new Dictionary<Keyboard.Key, bool>();
        foreach (var unityKey in _keyTable.Keys)
        {
            isDown[_keyTable[unityKey]] = Input.GetKey(unityKey);
        }
        _keyboardController.Update(new KeyDownData(Time.deltaTime, isDown));
    }
}
