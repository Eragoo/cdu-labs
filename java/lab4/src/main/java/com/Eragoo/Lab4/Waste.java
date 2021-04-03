package com.Eragoo.Lab4;

import lombok.Getter;
import lombok.ToString;

import java.io.Serializable;

@Getter
@ToString
public class Waste implements Weightable, Serializable {
    private final float weight;

    /**
     *
     * @param weight must be greater that 0
     */
    public Waste(float weight) {
        if(weight <= 0) {
            throw new IllegalArgumentException("Weight must be greater than 0");
        }
        this.weight = weight;
    }
}
