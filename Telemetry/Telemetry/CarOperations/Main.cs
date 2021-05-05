using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Telemetry
{
  class mainclass
  {
    static Dictionary<String, String> podio = new Dictionary<String, String>();

    public static void Main()
    {
      bool run = true;
      while (run == true)
      {
        Console.WriteLine("O que deseja fazer?\n" +
          "1 - Nova corrida\n" +
          "2 - Visualizar resultados completos última corrida\n" +
          "3 - Finalizar aplicação");
        try
        {
          int option = Int32.Parse(Console.ReadLine());
          switch (option)
          {
            case 1: StartRun(); break;
            case 2: ShowData(); break;
            case 3: run = false; break;
          }
        }
        catch
        {
        }
      }

    }

    public static void StartRun()
    {
      MoveCar move = new MoveCar();

      for (int i = 1; i < 11; i++)
      {
        podio = move.Start(i.ToString());
      }
      move.countdownEvent.Wait();
    }

    public static void ShowData()
    {
      MoveCar move = new MoveCar();
      move.ShowPodium(podio);
    }
  }
}
