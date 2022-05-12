using System.Security.AccessControl;

namespace Models;

public class Backpack
{
    public List<Item> Items { get; }
    public List<string> OtherItems { get; }
}