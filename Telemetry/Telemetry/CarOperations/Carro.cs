using System;

namespace Telemetry
{

  public class Carro
  {
    //Variável do estado do carro
    float loc = 1.0f, speed;

    //Setters e Getters das variáveis:

    public float getLoc()
    {
      return loc;
    }

    public void setLoc(float loc)
    {
      this.loc = loc;
    }

    public float getSpeed()
    {
      return speed;
    }

    public void setSpeed(float speed)
    {
      this.speed = speed;
    }
  }
}
