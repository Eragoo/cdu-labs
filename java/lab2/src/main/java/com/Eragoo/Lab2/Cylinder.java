package com.Eragoo.Lab2;

import lombok.AccessLevel;
import lombok.AllArgsConstructor;
import lombok.Getter;

@AllArgsConstructor
@Getter
public class Cylinder extends WoodForm {
    private final Wood wood;
    private final float length;
    private final float diameter;

    @Override
    public float volume() {
        return (float) (length * Math.PI * Math.pow(diameter / 2, 2));
    }
}
