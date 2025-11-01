using System;
using Stride.Core.Mathematics;
using Stride.Engine;

namespace CSharpBeginner.Code
{
    /// <summary>
    /// Liniear interpolation or in short 'Lerp' can be used to graduatly change a value from a start value to a target value 
    /// This is used during animation of models, ui elements, camera movements and many other scenarios
    /// This example uses Lerp to graduatly move from a start vector3 coordinate to target Vector3 coordinate
    /// The same thing can be done with Vector2 and Vector4
    /// <para>
    /// https://doc.stride3d.net/latest/en/tutorials/csharpbeginner/linear-interpolation.html
    /// </para>
    /// </summary>
    public class LerpDemo : SyncScript
    {
        public float AnimationTimer = 5.0f; //время анимки

        private float elapsedTime = 0;//прошедшее время
        private Random random = new Random(); //случайное число
        private Vector3 startPosition; //начальная точка
        private Vector3 targetPosition;//конечная точка

        public override void Start()
        {
            SetNewLerpTargetAndResetTimer();
        }

        public override void Update()
        {
            // Keep track of elapsed time
            var deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds; //время между кадрами
            elapsedTime += deltaTime; // добавляем время кадра к elapsedTime

            
            var lerpValue = elapsedTime / AnimationTimer; //прогресс анимации (от 0 до 1)

           
            Entity.Transform.Position = Vector3.Lerp(startPosition, targetPosition, lerpValue);//двигаем из стартовой позиции в конечную с таким то прогрессом 

            
            if (elapsedTime > AnimationTimer) //если прошло больше конца таймера
            {
                SetNewLerpTargetAndResetTimer();
            }

            DebugText.Print("Elapsed time: " + elapsedTime, new Int2(480, 120));
            DebugText.Print("Lerp value: " + lerpValue, new Int2(480, 140));
            DebugText.Print("Start position: " + startPosition, new Int2(480, 160));
            DebugText.Print("Target position: " + targetPosition, new Int2(480, 180));
        }


        private void SetNewLerpTargetAndResetTimer()
        {
            elapsedTime = 0; //сбрасываем таймер
            startPosition = Entity.Transform.Position; // меняем стартовую позицию
            targetPosition = new Vector3(random.Next(-2, 2), random.Next(0, 3), random.Next(-1, 1)); // выбираем рандомную позицию
        }
    }
}
