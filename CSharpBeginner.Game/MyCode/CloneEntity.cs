using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

namespace CSharpBeginner.MyCode;

public class CloneEntity : SyncScript
{
    // Declared public member fields and properties will show in the game studio
    public Entity entity; //переменная в которую через интерфейс сможем "закинуть" наш объект. Как packedScene в Godot
    private Entity clone; //создаю переменную где будет храниться клон.
    private Entity clone1;
    public override void Start()
    {
        //клон1
        clone = entity.Clone(); //клонируем
        Entity.Scene.Entities.Add(clone); //добавляем в сцену
        clone.Transform.Position += new Vector3(-1, 0, 0); // меняем позицию
        //клон2
        clone1 = entity.Clone();
        Entity.AddChild(clone1); //clone1.Transform.Parent = Entity.Transform
        clone1.Transform.Position += new Vector3(-2, 1, 0);
        clone1.Transform.Scale = new Vector3(0.5f);
    }

    public override void Update()
    {
        // Do stuff every new frame
    }
}
