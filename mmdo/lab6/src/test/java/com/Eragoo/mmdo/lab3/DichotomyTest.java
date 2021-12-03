package com.Eragoo.mmdo.lab3;

import org.apache.commons.math3.util.Precision;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class DichotomyTest {

    @Test
    void solve() {
        double[] solve = new DichotomyExample().solve(-10, 10, 0.0001);
        assertEquals(0, Math.abs(Precision.round(solve[0], 3)));
        assertEquals(1, Precision.round(solve[1], 3));
    }
}
