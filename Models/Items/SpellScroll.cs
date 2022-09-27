using Models.Common;
using Models.Interfaces;

namespace Models.Items;

public class SpellScroll : Item
{
    public Spell Spell { get; init; }
}