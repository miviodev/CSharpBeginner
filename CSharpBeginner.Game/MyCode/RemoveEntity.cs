using Stride.Core.Mathematics;
using Stride.Engine;

namespace CSharpBeginner.MyCode;

public class RemoveEntity : SyncScript
{
    // Declared public member fields and properties will show in the game studio
    public Entity entity; // что копировать будем
    private Entity clone; //клон внутри нашего объекта который потом удалим
    private Entity clone1; // клон внутри сцены
    private float timer = 0; // текущее время таймера
    private float currentTimer = 0;
    private float existTime = 4;
    private float goneTime = 2;
    private bool entitiesExist = false;
    public override void Start()
    {
        CloneEntityAndAddToScene();
        CloneEntityAndAddAsChild();
        entitiesExist = true;
    }
    private void CloneEntityAndAddToScene()
    {
        clone = entity.Clone(); //клонируем
        clone.Transform.Position += new Vector3(0, 0, -1); //перемещаем
        Entity.Scene.Entities.Add(clone); // добавляем в сцену 
    }
    private void CloneEntityAndAddAsChild()
    {
        clone1 = entity.Clone();
        clone1.Transform.Position += new Vector3(0, 0, 1);
        Entity.AddChild(clone1); //делаем дочерним
    }
    public override void Update()
    {
        timer += (float)Game.UpdateTime.Elapsed.TotalSeconds; //таймер (deltaTime)
        if (timer > currentTimer) //проверяем, надо ли чтото делать
        {
            if (entitiesExist) //Если клоны существуют то
            {
               // удаляем дочерний клон
                Entity.RemoveChild(clone1); // Alternative: clonedEntity1.Transform.Parent = null;

                // удаляем со сцены
                Entity.Scene.Entities.Remove(clone);

                // перезаписываем переменные в которых хранились клоны
                clone = null;
                clone1 = null;

                entitiesExist = false;
                currentTimer = goneTime;
            }
            else // если нет клонов то создаем
            {
                CloneEntityAndAddToScene();
                CloneEntityAndAddAsChild();
                entitiesExist = true;

                currentTimer = existTime;
            }

            // Reset timer
            timer = 0;
        }
    }

}
