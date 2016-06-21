using SGen;

namespace Evil_in_Dangeon
{
    static class Effects
    {
        /// <summary>
        /// Попадание пули
        /// </summary>
        /// <param name="bul">Пуля</param>
        /// <param name="Blood">Текёт ли кровь</param>
        public static void BulletHit(Bullet bul, bool Blood)
        {
            if (Blood)
            {
                for (int i = 0; i < 20; i++)
                    World.NewObject(new Blood((int)bul.Position.X + bul.Width / 2,
                        (int)bul.Position.Y + bul.Height / 2));
            }
            else
                World.NewObject(new Flash((int)bul.Position.X + bul.Width / 2 - 10,
                        (int)bul.Position.Y + bul.Height / 2 - 10));
        }
    }
}
