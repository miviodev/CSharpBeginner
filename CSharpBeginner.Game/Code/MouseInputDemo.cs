using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Input;

namespace CSharpBeginner.Code
{
    /// <summary>
    /// This script demonstrates how to check for any mouse input.
    /// <para>
    /// https://doc.stride3d.net/latest/en/tutorials/csharpbeginner/mouse-input.html
    /// </para>
    /// </summary>
    public class MouseInputDemo : SyncScript
    {
        public Entity BlueTeapot;
        public Entity YellowTeapot;
        public Entity GreenTeapot;
        public Entity PinkTeapot;

        private float currentScrollIndex = 0; // переменная, в которую будут записываться вращения колесиком

        public override void Start() { }

        public override void Update()
        {
            if (Input.HasMouse) // чекаем, есть ли мышь
            {
                DebugText.Print("Hold the left mouse button down to rotate the blue teapot", new Int2(400, 600));
                if (Input.IsMouseButtonDown(MouseButton.Left)) //если нажали ЛКМ
                {
                    var deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds; // получаем время кадра
                    BlueTeapot.Transform.Rotation *= Quaternion.RotationY(0.4f * deltaTime); // поворачиваем синий чайник
                }

                // Use 'IsMouseButtonPressed' for a single mouse click event. 
                DebugText.Print("Click the right mouse button to rotate the yellow teapot", new Int2(400, 620));
                if (Input.IsMouseButtonPressed(MouseButton.Right)) // если нажали ПКМ
                {
                    YellowTeapot.Transform.Rotation *= Quaternion.RotationY(-0.4f); //двигаем желтый чайник 
                }

                // 'IsMouseButtonReleased' is used for when you want to know when a mouse button is released after being either held down or pressed. 
                DebugText.Print("Press and release the scrollwheel to rotate the green teapot", new Int2(400, 640));
                if (Input.IsMouseButtonReleased(MouseButton.Middle)) // нажали колесико
                {
                    GreenTeapot.Transform.Rotation *= Quaternion.RotationY(0.4f); //двигаем зеленый чайник
                }

                currentScrollIndex += Input.MouseWheelDelta; // получаем разницу колесика между кадрами (дельту колесика)
                DebugText.Print("Scroll the mouse wheel to rotate the pink teapot. Scroll index: " + currentScrollIndex, new Int2(400, 660));
                PinkTeapot.Transform.Rotation = Quaternion.RotationY(0.02f * currentScrollIndex); // поворачиваем розовый чайник

                var mousePos = Input.AbsoluteMousePosition; // получаем позицию мыши в игре
                DebugText.Print("Mouse position: " + mousePos, new Int2(mousePos)); // выводимм
            }
        }
    }
}
