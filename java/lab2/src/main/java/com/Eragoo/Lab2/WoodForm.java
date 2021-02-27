package com.Eragoo.Lab2;

public abstract class WoodForm implements Weightable {
    protected abstract Wood getWood();
    public abstract float volume();
    public float getWeight() {
        return getWood().getDensity() * volume();
    }
}
