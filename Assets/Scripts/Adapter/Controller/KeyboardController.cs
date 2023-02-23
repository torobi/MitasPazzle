using Adapter.DTO;
using Domain.UseCase;
using UnityEngine;
using Zenject;

namespace Adapter.Controller
{
    public class KeyboardController
    {
        private UserUseCase _useCase;
        private readonly Keyboard _keyboard = new();

        public KeyboardController(UserUseCase useCase)
        {
            _useCase = useCase;
            RegisterCallbacks();
        }

        public void Update(KeyDownData data)
        {
            _keyboard.Update(data);
        }

        private void RegisterCallbacks()
        {
            _keyboard.RegisterCallBack(Keyboard.Key.MoveLeft, DownMoveLeftKey, 0.3f);
            _keyboard.RegisterCallBack(Keyboard.Key.MoveRight, DownMoveRightKey, 0.3f);
            _keyboard.RegisterCallBack(Keyboard.Key.TurnLeft, DownTurnLeftKey);
            _keyboard.RegisterCallBack(Keyboard.Key.TurnRight, DownTurnRightKey);
            _keyboard.RegisterCallBack(Keyboard.Key.Drop, DownDropKey, 0.25f);
            _keyboard.RegisterCallBack(Keyboard.Key.HardDrop, DownHardDropKey);
            _keyboard.RegisterCallBack(Keyboard.Key.Keep, DownKeepKey);
            _keyboard.RegisterCallBack(Keyboard.Key.Trash, DownTrashKey);
        }

        private void DownMoveRightKey()
        {
            _useCase.TryMoveRight();
        }

        private void DownMoveLeftKey()
        {
            _useCase.TryMoveLeft();
        }

        private void DownTurnRightKey()
        {
            _useCase.TryTurnRight();
        }

        private void DownTurnLeftKey()
        {
            _useCase.TryTurnLeft();
        }

        private void DownDropKey()
        {
            _useCase.TryDrop();
        }

        private void DownHardDropKey()
        {
            _useCase.HardDrop();
        }

        private void DownKeepKey()
        {
            _useCase.TryKeep();
        }

        private void DownTrashKey()
        {
            _useCase.TryTrash();
        }

    }
}