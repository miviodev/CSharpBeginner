using Stride.Core.Mathematics;
using Stride.Engine;

namespace CSharpBeginner.MyCode
{
    /// <summary>
    /// This script demonstrates how we can instantiate prefabs
    /// <para>
    /// https://doc.stride3d.net/latest/en/tutorials/csharpbeginner/instantiating-prefabs.html
    /// </para>
    /// </summary>
    public class Prefabs : SyncScript
    {
        public Prefab PileOfBoxesPrefab; //перетаскиваем префаб в редакторе
        public override void Start()
        {

            var pileOfBoxesInstance = PileOfBoxesPrefab.Instantiate(); // клонируем префаб (создаем инстанс)

            Entity.Scene.Entities.AddRange(pileOfBoxesInstance); //добавляем в сцену


            var pileOfBoxesPrefabFromContent = Content.Load<Prefab>("Prefabs/Pile of boxes"); //также можем его загрузить через папку assets 
            var pileOfBoxesInstance2 = pileOfBoxesPrefabFromContent.Instantiate(); //создаем копию префаба

            var pileOfBoxesParent = new Entity("PileOfBoxes2", new Vector3(0, 0, -2)); //делаем entity чтобы был parent для префаба
            pileOfBoxesParent.Transform.Rotation = Quaternion.RotationY(135); //вращаем
            foreach (var entity in pileOfBoxesInstance2) //добавляем все ентити из префаба (так как копируются все элементы префаба)
            {
                pileOfBoxesParent.AddChild(entity); //добавляем все энтити как дочерний элемент pileOfBoxesParent
            }
            Entity.Scene.Entities.Add(pileOfBoxesParent); // добавляем на сцену
        }

        public override void Update()
        {
            DebugText.Print("The original prefab", new Int2(310, 320));
            DebugText.Print("The prefab instance PileOfBoxes", new Int2(560, 370));
            DebugText.Print("The prefab instance PileOfBoxes2 with custom parent", new Int2(565, 650));
        }
    }
}
