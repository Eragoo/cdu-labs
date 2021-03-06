package com.Eragoo.Lab3;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NonNull;

import java.io.Serializable;

@Getter
public class Cylinder extends WoodForm implements Serializable {
    private final Wood wood;
    private final float length;
    private final float diameter;

    public Cylinder(Wood wood, float length, float diameter) {
        if(wood == null  || length <= 0 || diameter <= 0) {
            throw new IllegalArgumentException();
        }
        this.wood = wood;
        this.length = length;
        this.diameter = diameter;
    }

    @Override
    public float volume() {
        return (float) (length * Math.PI * Math.pow(diameter / 2, 2));
    }
}
