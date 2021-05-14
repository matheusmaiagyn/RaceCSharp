using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Telemetry
{
  class MoveCar
  {
    public Carro car = new Carro();
    Random random = new Random();
    static int howManyCars = 10;
    static List<String> finish = new List<string>(howManyCars);
    public CountdownEvent countdownEvent = new CountdownEvent(howManyCars);

    Dictionary<String, String> value = new Dictionary<String, String>();

    public void Move(String numCar)
    {
      int maxDistance = 3000;
      value.Clear();
      car.setSpeed((float)random.NextDouble());
      Stopwatch sw = new Stopwatch();

      sw.Start();
      while (car.getLoc() <= maxDistance)
      {
        if (random.Next(0, 1) == 1)
          car.setLoc(car.getLoc() + car.getSpeed());
        else
        {
          car.setSpeed((float)random.NextDouble());
          car.setLoc(car.getLoc() + car.getSpeed());
        }
        Console.WriteLine(numCar + " localização: " + car.getLoc());
      }
      sw.Stop();

      countdownEvent.Signal();
      value.Add(numCar, sw.Elapsed.ToString());
    }

    public void ShowPodium(Dictionary<String, String> podio)
    {
      Console.WriteLine("\nPodio: ");

        foreach (var p in podio)
          Console.WriteLine(p.Key + " Tempo: " + p.Value);
    }

    public Dictionary<String, String> Start(String numCar)
    {
      Thread t = new Thread(() => Move(numCar));
      t.Start();
      return value;
    }
  }
}
