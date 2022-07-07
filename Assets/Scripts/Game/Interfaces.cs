public interface HealthInterfaces
{
    //Interfaces to hold what functions I want to occur
    //when the gameObject enters/exits a trigger
    public void Heal(float healAmount);
    public void Damage(float damageAmount);
    public void DOT(bool doDOT);
    public void HOT(bool doHOT);
}

public interface ProgressInterfaces
{
    public void ProgressIncrease(float increaseProgress,float cap);
    public void ProgressDecrease(float decreaseProgress);
}