using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    class Bullet : Box
    {
        public static Texture2D Texture;
        public static SoundEffect Sound;
        public static SoundEffect SountRikoshet;
        public bool Enemy;
        public int Damage;
        public int Side;

        public Bullet(int x, int y, int Side, int Damage, bool Enemy) : base(x, y, 8, 4)
        {
            AnimationSide = Side;
            Sound.Play();
            this.Damage = Damage;
            this.Enemy = Enemy;
            this.Side = Side;
        }

        public override void Collision(Box box)
        {
        }

        public override void Draw()
        {
            Draw(Texture);
        }

        public override void Trigger()
        {
        }

        public override void Update()
        {
            Position.X += AnimationSide * 20;
            if (WhatIsTiler(4, 2) == 1)
            {
                World.NewObject(new Flash((int)Position.X - 6, (int)Position.Y - 8));
                PlayIfVisible(SountRikoshet, false);
                Destroy();
            }
        }
    }
}
