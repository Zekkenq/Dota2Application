using System;
using System.Collections.Generic;
using System.Text;

namespace Dota2DesktopApp.Model
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Avatar { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public double HealthPoint { get; set; }
        public double ManaPoint { get; set; }
        public double ArmorPoint { get; set; }
        public double AttackSpeed { get; set; }
        public double MoveSpeed { get; set; }
    }
}
