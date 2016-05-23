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
            if (code == 60) Objects.Add(new SpiderOnWeb(x, y));
            if (code == 61) Objects.Add(new Spider(x, y));
        }
    }
}
