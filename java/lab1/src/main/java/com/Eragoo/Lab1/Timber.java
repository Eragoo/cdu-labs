package com.Eragoo.Lab1;

import lombok.AllArgsConstructor;

@AllArgsConstructor
public class Timber {
    private final Wood wood;
    private final float length;
    private final float width;
    private final float height;

    public float volume() {
        return height * width * length;
    }

    public float weight() {
        return wood.getDensity() * volume();
    }
}
