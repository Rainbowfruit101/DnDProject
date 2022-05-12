using System;
namespace Models;

public class Characteristic
{
    public string Name { get; }
    public int Value { get; set; }
    public int Modifier => (int) Math.Floor((Value - 10) / 2.0);
}