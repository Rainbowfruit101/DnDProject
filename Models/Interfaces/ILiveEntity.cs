﻿using Models.Common;
using Models.LiveEntities;

namespace Models.Interfaces;

public interface ILiveEntity : IIdentifiable
{
    public string Name { get; }
    public int Level { get; }
    public string Ideology { get; }
    public int MaxHealth { get; }
    public int CurrentHealth { get; }
    public List<Characteristic> Сharacteristics { get; }
    public string Background { get; }
    public LiveEntityClass PersonClass { get; }
    public LiveEntityRace PersonRace { get; }
    public List<Spell> Spells { get; }
    public string ImageSource { get; }
    public List<Status> CreatureStatus { get; }
}