package com.Eragoo.university;

import org.junit.jupiter.api.Test;

import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;

class CalculatorTest {
    @Test
    public void testMod() {
        assertEquals(1, Calculator.mod(10, 3));
        assertEquals(0, Calculator.mod(4, 2));
        assertEquals(2, Calculator.mod(8, 3));
        assertEquals(-1, Calculator.mod(-10, 3));
        assertEquals(1, Calculator.mod(1, 10));
    }

    @Test
    public void testAbs() {
        assertEquals(5, Calculator.abs(-5));
        assertEquals(5, Calculator.abs(5));
        assertEquals(0, Calculator.abs(0));
        assertEquals(12345, Calculator.abs(12345));
        assertEquals(12345, Calculator.abs(-12345));
    }

    @Test
    public void testSub() {
        assertEquals(1, Calculator.sub(3, 2));
        assertEquals(-2, Calculator.sub(2, 4));
        assertEquals(0, Calculator.sub(5, 5));
        assertEquals(-50, Calculator.sub(50, 100));
        assertEquals(100, Calculator.sub(150, 50));
    }

    @Test
    public void testCreateStack() {
        assertTrue(Calculator.createStack() instanceof ArrayList);
        assertTrue(Calculator.<Integer>createStack().isEmpty());
        assertEquals(0, Calculator.<String>createStack().size());
        assertNotNull(Calculator.<Double>createStack());
        assertNotSame(Calculator.createStack(), Calculator.createStack());
    }

    @Test
    public void testMult() {
        assertEquals(6, Calculator.mult(2, 3));
        assertEquals(0, Calculator.mult(0, 5));
        assertEquals(-10, Calculator.mult(-2, 5));
        assertEquals(25, Calculator.mult(5, 5));
        assertEquals(0, Calculator.mult(100, 0));
    }

    @Test
    public void testDiv() {
        assertEquals(2, Calculator.div(4, 2));
        assertThrows(ArithmeticException.class, () -> Calculator.div(4, 0));
        assertEquals(0, Calculator.div(0, 5));
        assertEquals(-2, Calculator.div(-6, 3));
        assertEquals(3, Calculator.div(15, 5));
    }

}