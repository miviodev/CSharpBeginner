using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Annotations; // надо добавить для   [DataMemberRange(1, 100, 0.1, 1, 3)]
using Stride.Core.Mathematics;
using Stride.Core;
using Stride.Input;
using Stride.Engine;

namespace CSharpBeginner.MyCode;

public class PropertyScript : SyncScript
{
    // Declared public member fields and properties will show in the game studio

    public string Str = "hello"; //public в начале, говорит что мы можем менять эту property (переведу как настрока) из другого скрипта или же из интерфейса stride
    public int Int = 123; 
    public int IntSecond;
    public float floatA = 10.0f;
    public bool boolean = true;
    public Vector2 Vector2D; //тоже самое что public Vector2 Vector2D = new Vector2(0,0);
    public Vector3 Vector3D = new Vector3(1,2,3);
    public Color SomeColor = Color.Red;
    
    //DataMemberRange(minimum, maximum,smallStep, largeStep,decimalPlaces)
    [DataMemberRange(1, 100, 0.1, 1, 3)] //при перетаскивании берет smallStep значение. нажимая юзает largeStep чтобы перетаскивать
    public float RangedFloat = 10.0f;
    
    //энтити и компоненты
    public Entity ASingleEntity;
    public CameraComponent ASingleCameraComponent;
    
    //списки
    public List<string> StringList = new List<string>();
    public List<Entity> EntityList = new List<Entity>();
    public List<CameraComponent> CameraList = new List<CameraComponent>();
    
    //словари какие-то сам еще не разобрался
    public Dictionary<string, int> aSimpleDictionary = new Dictionary<string, int>(); //Dictionaries also need to be initialized. The first value needs to be a primitive type like string
    [DataMemberIgnore] // "скрывает" HideMe из интерфейса настроек stride
    public string HideMe;
    // Енумы могут быть использованы для раскрывающихся списков
    public CharacterType Character;
    public enum CharacterType
        {
            Warrior,
            Archer,
            Mage
        }
    public string Explanation;
    public override void Update()
    {
        // Do stuff every new frame
        //Ну и теперь ВЫВОДИМ ЭТО ВСЕ!
            var x = 400;
            DebugText.Print("Float: " + floatA,      new Int2(x, 220));
            DebugText.Print("Integer: " + Int,  new Int2(x, 200));
            DebugText.Print("Boolean: " + boolean,  new Int2(x, 240));
            DebugText.Print("String: " + Str,    new Int2(x, 260));
            DebugText.Print("Vector2: " + Vector2D,  new Int2(x, 280));
            DebugText.Print("Vector3: " + Vector3D,  new Int2(x, 300));
            DebugText.Print("Color: " + SomeColor,      new Int2(x, 320));
            DebugText.Print("String list count: " + StringList.Count, new Int2(x, 340));
            DebugText.Print("Entity list count: " + EntityList.Count, new Int2(x, 360));
            DebugText.Print("Camera list count: " + CameraList.Count, new Int2(x, 380));
    }
}
