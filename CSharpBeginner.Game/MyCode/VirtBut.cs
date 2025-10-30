using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

namespace CSharpBeginner.MyCode;

public class VirtBut : SyncScript
{
    // Declared public member fields and properties will show in the game studio
    public Entity teapot;
    public override void Start()
    {
        // создаем вирт кнопку
        Input.VirtualButtonConfigSet = Input.VirtualButtonConfigSet ?? new VirtualButtonConfigSet();
        var forwardUp = new VirtualButtonBinding("Forward", VirtualButton.Keyboard.Up); //биндим стрелку вверх
        var forwardW = new VirtualButtonBinding("Forward", VirtualButton.Keyboard.W); //биндим W
        var forwardLeftMouse = new VirtualButtonBinding("Forward", VirtualButton.Mouse.Left); //ЛКМ
        var forwardLeftTrigger = new VirtualButtonBinding("Forward", VirtualButton.GamePad.LeftTrigger); //трригер


        var virtualbuttonForward = new VirtualButtonConfig //создаем конфиг вирт кнопки и запихиваем туда наши бинды
        {
            forwardUp,
            forwardW,
            forwardLeftMouse,
            forwardLeftTrigger
        };
        Input.VirtualButtonConfigSet.Add(virtualbuttonForward); // добавляем конфиг к вирт кнопке

    }

    public override void Update()
    {
        var forward = Input.GetVirtualButton(0, "Forward"); //создаем переменную, в которой будет типо нажата кнопка значит 1 не нажата значит 0
        if (forward > 0)
        {
            var deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds;
            teapot.Transform.Rotation *= Quaternion.RotationY(0.6f * forward * deltaTime);
        }
    }
}

