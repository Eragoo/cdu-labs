package com.Eragoo.Lab3;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

class TimberTest {

    @Test
    void volume() {
        float expected = 3 * 3 * 3;
        Timber sample = new Timber(new Wood(1L, "Sample", 1f), 3f, 3f, 3f);
        assertEquals(expected, sample.volume());
    }

    @Test
    void weight() {
        float expected = 3 * 3 * 3 * 3;
        Timber sample = new Timber(new Wood(1L, "Sample", 3f), 3f, 3f, 3f);
        assertEquals(expected, sample.getWeight());
    }
}