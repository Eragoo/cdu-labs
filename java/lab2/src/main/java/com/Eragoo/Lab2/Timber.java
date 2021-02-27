package com.Eragoo.Lab2;

import lombok.AccessLevel;
import lombok.AllArgsConstructor;
import lombok.Getter;

@AllArgsConstructor
public class Timber extends WoodForm{
    @Getter(AccessLevel.PROTECTED)
    private final Wood wood;
    private final float length;
    private final float width;
    private final float height;

    public float volume() {
        return height * width * length;
    }
}
