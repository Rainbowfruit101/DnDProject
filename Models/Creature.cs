﻿using Models.Interfaces;

namespace Models;

public class Creature : ILiveEntity
{
    public string Name { get; init; }
    public int Level { get; init; }
    public string Ideology { get; init; }
    public int MaxHealth { get; init; }
    public int CurrentHealth { get; init; }
    public List<Characteristic> Сharacteristics { get; init; }
    public string Background { get; init; }
    public LiveEntityClass PersonClass { get; init; }
    public LiveEntityRace PersonRace { get; init; }
    public List<Spell> Spells { get; init; }
    public string ImageSource { get; init; }
    public List<Status> CreatureStatus { get; init; }
    
    public string Description { get; init; }
}