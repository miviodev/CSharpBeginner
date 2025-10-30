using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

namespace CSharpBeginner.MyCode;

public class GetPosition : SyncScript
{
    // Declared public member fields and properties will show in the game studio
    

    public override void Start()
    {
        // Initialization of the script.
    }

    public override void Update()
    {
        // Do stuff every new frame
       // Entity.Transform.Position = new Vector3(0,0,0); менять надо так, а не localpos = new Vector3(....) так как мы переприсваиваем переменную
       Vector3 localpos = Entity.Transform.Position; //Entity можно юзать ток в Update и Start
       Vector3 worldpos = Entity.Transform.WorldMatrix.TranslationVector; //глобальная позиция
       
       DebugText.Print(Entity.Name + " local pos = " + localpos, new Int2(400, 450));
       DebugText.Print(Entity.Name + " world pos = " + worldpos, new Int2(400, 480));
    }
}
