using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Telemetry
{
  class MoveCar
  {
    public Carro car = new Carro();
    Random random = new Random();
    static int howManyCars = 10;
    static List<String> podio = new List<string>(howManyCars);
    int count = 0;
    public CountdownEvent countdownEvent = new CountdownEvent(howManyCars);

    public void Move(String numCar)
    {
      int maxDistance = 3000;
      podio.Clear();
      car.setSpeed((float)random.NextDouble());

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

      count += 1;
      podio.Add(numCar);
      countdownEvent.Signal();
    }

    public void ShowPodium()
    {
        Console.WriteLine("\nPodio: ");
        foreach (String p in podio)
          Console.WriteLine(p);
    }

    public void Start(String numCar)
    {
      Thread t = new Thread(() => Move(numCar));
      t.Start();
    }
  }
}
