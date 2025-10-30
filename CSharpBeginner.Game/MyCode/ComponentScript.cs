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

public class ComponentScript : SyncScript //тип определяется по классу, например ComponentScript это тип
{
    // Declared public member fields and properties will show in the game studio
    AmmoComponent ammoComponent; //AmmoComponent это класс, в другом скрипте (AmmoComponent.cs)
    IEnumerable<AmmoComponent> ammoComponents; //IEnumerable — это базовый интерфейс для всех не универсальных коллекций, которые можно перечислить.
    public override void Start()
    {
        ammoComponent = Entity.Get<AmmoComponent>(); // получаем ссылку на компонент (скрипт)


        ammoComponents = Entity.GetAll<AmmoComponent>(); //получаем все компоненты с именем AmmoComponent

        //Entity.Remove(ammoComponent); удаляет компонент с объекта
        //Entity.Remove<AmmoComponent>(); удалит рандомный компонент с типом AmmoComponent
        //Entity.RemoveAll<AmmoComponent>(); удалит все компоненты которые имеют тип AmmoComponent
    }

    public override void Update()
    {
        DebugText.Print("Curret ammo: " + ammoComponent.GetRemainingAmmo(), new Int2(300, 300));
    }
}
