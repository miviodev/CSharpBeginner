using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using CSharpBeginner.Code;

namespace CSharpBeginner.MyCode;

public class AddComponent : SyncScript
{
    // Declared public member fields and properties will show in the game studio
    private AmmoComponent ammoComponent; // создаем переменную
    public override void Start()
    {
        // Initialization of the script.
        ammoComponent = new AmmoComponent(); // присваиваем ей новый чето там (ну типо как я понял мы присваеваем ей класс с AmmoComponent.cs)
        Entity.Add(ammoComponent); //добавили компонент со скрипта AmmoComponent.cs (там типо класс с таким названием и поэтому такой тип)
    }

    public override void Update()
    {
        DebugText.Print("ammo " + ammoComponent.GetRemainingAmmo(), new Int2(250, 250));
    }
}
