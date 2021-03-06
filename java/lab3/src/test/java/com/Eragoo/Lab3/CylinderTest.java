package com.Eragoo.Lab3;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

class CylinderTest {

    @Test
    void volume() {
        Cylinder cylinder = new Cylinder(new Wood(1, "Sample", 2.3f), 10, 10);
        float expected = (float) (Math.PI * Math.pow(cylinder.getLength() / 2, 2) * cylinder.getLength());
        assertEquals(expected, cylinder.volume());
    }
}