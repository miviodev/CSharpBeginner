using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Rendering.ProceduralModels;

namespace CSharpBeginner.MyCode;

public class keyboard : SyncScript
{
    // Declared public member fields and properties will show in the game studio
    public Entity teapot;
    public override void Start()
    {
        // не нужен
    }

    public override void Update()
    {
        if (Input.HasKeyboard)
        {
            if (Input.IsKeyDown(Keys.D1)) //если нажата цифра 1
            {
                var deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds;
                teapot.Transform.Rotation *= Quaternion.RotationY(0.3f * deltaTime);
            }
            DebugText.Print("Hold 1 To rotate; Press F to rotate; release Space to rotate", new Int2(300, 300));
            if (Input.IsKeyPressed(Keys.F)) //если нажали F
            {
                teapot.Transform.Rotation *= Quaternion.RotationY(-0.4f);
            }
            if (Input.IsKeyReleased(Keys.Space)) //если отпустили пробел
            {
                teapot.Transform.Rotation *= Quaternion.RotationY(0.4f);
            }
        }
    }
}
