using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TowerDefenseForms
{
    class SlowTower:Tower
    {
        private int level;
        private float damage;

        private float effectTime;

        private float range;

        private float slowFactor;

        private float rateOfFire;
        private float fireTimer;
        private int buyPrice;
        private int sellPrice;

        public SlowTower(int level, float damage,float effectTime, float range,float slowFactor, float rateOfFire, int buyPrice, int sellPrice, PointF position, PointF[] shape, Color color)
            : base(level, damage, range, rateOfFire, buyPrice, sellPrice, position, shape, color)
        {
            this.level = level;
            this.damage = damage;
            this.effectTime = effectTime;
            this.range = range;
            this.slowFactor = slowFactor;
            this.rateOfFire = rateOfFire;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
        }

        public override void Attack()
        {
            base.Attack();
            //Create IceEffect
        }
    }
}
