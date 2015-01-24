using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.source.Entities.Controllers
{
    interface IInputController
    {
        void HandleOnStickActive(StickType p_stickType, float p_speed, int p_playerIndex);
        void HandleOnButtonReleased(ControllerButton p_controllerButton, int p_playerIndex);
        void HandleOnButtonPressed(ControllerButton p_controllerButton, int p_playerIndex);
    }
}