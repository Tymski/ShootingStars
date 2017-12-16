using System;
using GamepadInput;
using UnityEngine;

namespace Managers.InputManager
{
    public enum PlayerAxis
    {
        HORIZONTAL,
        VERTICAL
    }

    public enum PlayerButton
    {
        A,
        B,
        X,
        Y
    }

    [Serializable]
    public class Player
    {
        [SerializeField]
        private int _id;

        private GamePad.Index _index;

        private bool _wasAPressed, _wasBPressed, _wasXPressed, _wasYPressed;

        [SerializeField]
        private ControllerScheme _scheme;

        private GamepadState _state;


        public void InitializePlayer()
        {
            _index = _scheme.ControllerIndex;

        }

        public void Update()
        {
            if (!_scheme.IsGamepad)
                return;
            
            _state = GamePad.GetState(_index);

            if(!_scheme.IsRightPlayer)
            {

                if (_wasAPressed && !_state.Down)
                    _wasAPressed = false;

                if (_wasBPressed && !_state.Right)
                    _wasBPressed = false;

                if (_wasXPressed && !_state.Left)
                    _wasXPressed = false;

                if (_wasYPressed && !_state.Up)
                    _wasYPressed = false;
            }

        }

        public float GetAxis(PlayerAxis axis)
        {
            _state = GamePad.GetState(_index);

            if (_scheme.IsGamepad)
            {
                switch (axis)
                {
                    case PlayerAxis.HORIZONTAL:

                        if (_scheme.IsRightPlayer)
                            return _state.rightStickAxis.x;

                        return _state.LeftStickAxis.x;

                    case PlayerAxis.VERTICAL:

                        if (_scheme.IsRightPlayer)
                            return _state.rightStickAxis.y;

                        return _state.LeftStickAxis.y;
                    default:
                        throw new ArgumentOutOfRangeException("axis", axis, null);
                }
            }
            else
            {
                switch (axis)
                {
                    case PlayerAxis.HORIZONTAL:
                        return Input.GetAxis(_scheme.AxisX);
                    case PlayerAxis.VERTICAL:
                        return Input.GetAxis(_scheme.AxisY);
                    default:
                        throw new ArgumentOutOfRangeException("axis", axis, null);
                }
            }
        }

        public bool GetButtonDown(PlayerButton button)
        {
            _state = GamePad.GetState(_index);

            if (_scheme.IsGamepad)
            {
                switch (button)
                {
                    case PlayerButton.A:
                        if(_scheme.IsRightPlayer)
                            return GamePad.GetButtonDown(GamePad.Button.A, _index);
                        else
                        {
                            if (!_wasAPressed)
                            {
                                if (_state.Down)
                                {
                                    _wasAPressed = true;
                                    return true;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                    case PlayerButton.B:
                        if (_scheme.IsRightPlayer)
                            return GamePad.GetButtonDown(GamePad.Button.B, _index);
                        else
                        {
                            if (!_wasBPressed)
                            {
                                if (_state.Right)
                                {
                                    _wasBPressed = true;
                                    return true;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                    case PlayerButton.X:
                        if (_scheme.IsRightPlayer)
                            return GamePad.GetButtonDown(GamePad.Button.X, _index);
                        else
                        {
                            if (!_wasXPressed)
                            {
                                if (_state.Left)
                                {
                                    _wasXPressed = true;
                                    return true;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                    case PlayerButton.Y:
                        if (_scheme.IsRightPlayer)
                            return GamePad.GetButtonDown(GamePad.Button.Y, _index);
                        else
                        {
                            if (!_wasYPressed)
                            {
                                if (_state.Up)
                                {
                                    _wasYPressed = true;
                                    return true;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                    default:
                        throw new ArgumentOutOfRangeException("button", button, null);
                }
            }
            else
            {
                switch (button)
                {
                    case PlayerButton.A:
                        return Input.GetKeyDown(_scheme.ButtonA);
                    case PlayerButton.B:
                        return Input.GetKeyDown(_scheme.ButtonB);
                    case PlayerButton.X:
                        return Input.GetKeyDown(_scheme.ButtonX);
                    case PlayerButton.Y:
                        return Input.GetKeyDown(_scheme.ButtonY);
                    default:
                        throw new ArgumentOutOfRangeException("button", button, null);
                }
            }
        }

        public bool GetButtonUp(PlayerButton button)
        {
            _state = GamePad.GetState(_index);

            if (_scheme.IsGamepad)
            {
                switch (button)
                {
                    case PlayerButton.A:
                        if (_scheme.IsRightPlayer)
                            return GamePad.GetButtonUp(GamePad.Button.A, _index);
                        else
                        {
                            if (_wasAPressed)
                            {
                                if (!_state.Down)
                                {
                                    _wasAPressed = false;
                                    return true;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                    case PlayerButton.B:
                        if (_scheme.IsRightPlayer)
                            return GamePad.GetButtonUp(GamePad.Button.B, _index);
                        else
                        {
                            if (_wasBPressed)
                            {
                                if (!_state.Right)
                                {
                                    _wasBPressed = false;
                                    return true;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                    case PlayerButton.X:
                        if (_scheme.IsRightPlayer)
                            return GamePad.GetButtonUp(GamePad.Button.X, _index);
                        else
                        {
                            if (_wasXPressed)
                            {
                                if (!_state.Left)
                                {
                                    _wasXPressed = false;
                                    return true;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                    case PlayerButton.Y:
                        if (_scheme.IsRightPlayer)
                            return GamePad.GetButtonUp(GamePad.Button.Y, _index);
                        else
                        {
                            if (_wasYPressed)
                            {
                                if (!_state.Up)
                                {
                                    _wasYPressed = false;
                                    return true;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                    default:
                        throw new ArgumentOutOfRangeException("button", button, null);
                }
            }
            else
            {
                switch (button)
                {
                    case PlayerButton.A:
                        return Input.GetKeyUp(_scheme.ButtonA);
                    case PlayerButton.B:
                        return Input.GetKeyUp(_scheme.ButtonB);
                    case PlayerButton.X:
                        return Input.GetKeyUp(_scheme.ButtonX);
                    case PlayerButton.Y:
                        return Input.GetKeyUp(_scheme.ButtonY);
                    default:
                        throw new ArgumentOutOfRangeException("button", button, null);
                }
            }
        }
        
        public bool GetButton(PlayerButton button)
        {
            _state = GamePad.GetState(_index);

            if (_scheme.IsGamepad)
            {
                switch (button)
                {
                    case PlayerButton.A:
                        if (_scheme.IsRightPlayer)
                            return GamePad.GetButton(GamePad.Button.A, _index);
                        else
                            return _state.Down;
                    case PlayerButton.B:
                        if (_scheme.IsRightPlayer)
                            return GamePad.GetButton(GamePad.Button.B, _index);
                        else
                            return _state.Right;
                    case PlayerButton.X:
                        if (_scheme.IsRightPlayer)
                            return GamePad.GetButton(GamePad.Button.X, _index);
                        else
                            return _state.Left;
                    case PlayerButton.Y:
                        if (_scheme.IsRightPlayer)
                            return GamePad.GetButton(GamePad.Button.Y, _index);
                        else
                            return _state.Up;
                    default:
                        throw new ArgumentOutOfRangeException("button", button, null);
                }
            }
            else
            {
                switch (button)
                {
                    case PlayerButton.A:
                        return Input.GetKey(_scheme.ButtonA);
                    case PlayerButton.B:
                        return Input.GetKey(_scheme.ButtonB);
                    case PlayerButton.X:
                        return Input.GetKey(_scheme.ButtonX);
                    case PlayerButton.Y:
                        return Input.GetKey(_scheme.ButtonY);
                    default:
                        throw new ArgumentOutOfRangeException("button", button, null);
                }
            }
        }
    }
}
