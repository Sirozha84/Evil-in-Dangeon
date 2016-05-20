using Microsoft.Xna.Framework;
using SGen;

namespace Evil_in_Dangeon
{
    class MyWorld : World
    {
        public MyWorld(string MapFile, Game game) : base(MapFile, game, typeof(Hero)) { }
        public override void AddObject(ushort code, int x, int y)
        {
            if (code == 3) { Box o = new Hero(x, y); Objects.Add(o); Players.Add(o); }
            if (code == 5) Objects.Add(new DeathZone(x, y, 5));
            if (code == 20) Objects.Add(new Coin(x + 30, y + 30, 0, true));
            if (code == 21)
            {
                Objects.Add(new Coin(x + 10, y + 40, 0, true));
                Objects.Add(new Coin(x + 50, y + 40, 0, true));
                Objects.Add(new Coin(x + 30, y + 10, 0, true));
            }
            if (code == 22) Objects.Add(new Coin(x + 30, y + 30, 1, true));
            if (code == 23)
            {
                Objects.Add(new Coin(x + 10, y + 40, 1, true));
                Objects.Add(new Coin(x + 50, y + 40, 1, true));
                Objects.Add(new Coin(x + 30, y + 10, 1, true));
            }
            if (code == 24) Objects.Add(new Coin(x + 30, y + 30, 2, true));
            if (code == 25)
            {
                Objects.Add(new Coin(x + 10, y + 40, 2, true));
                Objects.Add(new Coin(x + 50, y + 40, 2, true));
                Objects.Add(new Coin(x + 30, y + 10, 2, true));
            }
            /*if (code == 7) Objects.Add(new Platform(x, y, 1));
                        if (code == 8) Objects.Add(new Platform(x, y, 2));
                        if (code == 9) Objects.Add(new PoisonBuble(x, y));
                        if (code == 10) Objects.Add(new Coin(x + 24, y + 48, 1, true));
                        if (code == 11)
                        {
                            Objects.Add(new Coin(x + 24, y + 12, 1, true));
                            Objects.Add(new Coin(x, y + 48, 1, true));
                            Objects.Add(new Coin(x + 48, y + 48, 1, true));
                        }
                        if (code == 17) Objects.Add(new Platform(x, y, 3));
                        if (code == 18) Objects.Add(new Platform(x, y, 4));
                        if (code == 19) Objects.Add(new Blob(x, y));
                        if (code == 20) Objects.Add(new TrashCan(x, y - 40));
                        if (code == 21) Objects.Add(new Bomb(x + 15, y + 60));*/
        }
    }
}
