using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

namespace CSharpBeginnerNow.MyScriptsTutorials;

public class childentities : SyncScript
{
    public override void Start()
    {
        //получаем первого ребенка
        // Entity это элемент к которому прекреплен скрипт!
        var child0 = Entity.GetChild(0);
        var child1 = Entity.GetChild(1);
        //var child2 = Entity.GetChild(2); юзать GetChild если на 100 проц уверены что он есть
        var children = Entity.GetChildren(); // возращает всех детей "первого слоя: например
    }

    public override void Update()
    {
        // куда рисовать по x и y и так же offset
        var drawX = 400;
        var drawY = 200;
        var increment = 50;
        DebugText.Print(Entity.Name, new Int2(drawX, drawY)); //печатаем имя нашего энтити

        foreach (var child in Entity.GetChildren()) // аналог for in в python, те тут for child in Entuty.GetChildren()
        {
            drawY += increment; //смещаемся по Y вниз 
            DebugText.Print(child.Name, new Int2(drawX + increment, drawY)); //печатаем с одинаковым offset по X
            //теперь добываем все дочерние элементы дочерних элементов)
            foreach (var subchild in child.GetChildren())
            {
                drawY += increment; //смещаемся по Y вниз 
                DebugText.Print(subchild.Name, new Int2(drawX + (increment * 2), drawY));
            }
        }
    }
}
