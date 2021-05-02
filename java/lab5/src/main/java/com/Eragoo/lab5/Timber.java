package com.Eragoo.lab5;

import lombok.AccessLevel;
import lombok.Getter;
import lombok.Setter;

import java.io.Serializable;

@Getter
@Setter
public class Timber extends WoodForm implements Serializable {
    @Getter(AccessLevel.PROTECTED)
    private Wood wood;
    private float length;
    private final float width;
    private final float height;

    public Timber(Wood wood, float length, float width, float height) {
        if(wood == null  || length <= 0 || width <= 0 || height <= 0) {
            throw new IllegalArgumentException();
        }
        this.wood = wood;
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public float volume() {
        return height * width * length;
    }
}
