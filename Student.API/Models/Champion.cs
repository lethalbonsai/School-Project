﻿namespace Student.API.Models
{
    public class Champion
    {
        public long  Id { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string FullName { get; set; }
        public string Role { get; set;}
        public float AttackDamage { get; set;}
        public float AbilityPower { get; set;}
        public float Health { get; set;}
        public float AttackSpeed { get; set;}
        public float Mana { get; set;}
        public float Armor { get; set;}
        public float MagicResist { get; set;}
        public float CritDamage { get; set;}
        public float MovementSpeed { get; set;}
        public float AttackRange { get; set;}
    }
}