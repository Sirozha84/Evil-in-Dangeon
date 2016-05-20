using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    class DeathZone : Box
    {
        public int Damage;
        public DeathZone(int x, int y, int Damage) : base(x, y) { }
        public override void Collision(Box box) { }
        public override void Draw() { }
        public override void Trigger() { }
        public override void Update() { }
    }
}
