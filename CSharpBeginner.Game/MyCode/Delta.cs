using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

namespace CSharpBeginner.MyCode;

public class Delta : SyncScript
{
    private float rotationSpeed = 0.6f; //скорость вращения манекена в радианах/сек
    private float totalTime = 0; // общее время работы игры
    private float countdownStartTime = 5.0f; // время начала таймера
    private float countdownTime = 0; //текущее значение таймера

    public override void Start() { }

    public override void Update()
    { // получаем время между кадрами
        var deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds; // Game - главный объект игры; UpdateTime - информация о времени обновления игры; Elapsed - время, прошедшее с последнего кадра
                                                                     // .TotalSeconds Преобразует это время в секунды(обычно это маленькое число) Например: 0.016(для 60 FPS) или 0.033(для 30 FPS)
                                                                     //(float) превращает то что возвращает Game.UpdateTime.Elapsed.TotalSeconds в флоат
        totalTime += deltaTime; // время работы игры
        countdownTime -= deltaTime; // уменьшаем таймер
        if (countdownTime < 0)
        {
            countdownTime = countdownStartTime;
            rotationSpeed *= -1;
        }
        Entity.Transform.Rotation *= Quaternion.RotationY(deltaTime * rotationSpeed); //вращаем по Y 
        DebugText.Print("Delta Time: " + deltaTime, new Int2(200, 200));
        DebugText.Print("Timer: " + countdownTime, new Int2(200, 220));
    }
}
