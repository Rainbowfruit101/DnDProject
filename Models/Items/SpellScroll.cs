using Models.Common;

namespace Models.Items;

public class SpellScroll : Item
{
    public Spell Spell { get; init; }
}