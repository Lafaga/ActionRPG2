namespace CollisionSample
{
    public class Heal : Damage
    {
        public new void Setup(int damage, float duration)
        {
            this.damage = damage;
            this.duration = duration;
            tmpDamage.text = $"+{damage}";
        }
    }
}