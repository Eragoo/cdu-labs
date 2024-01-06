package com.Eragoo.university;

import java.util.ArrayList;

public class Calculator {
    public static int mod(long a, long b) {
        return (int) (a % b);
    }

    public static int abs(long a) {
        return (int) Math.abs(a);
    }

    public static int sub(long a, long b) {
        return (int) (a - b);
    }

    public static <T> ArrayList<T> createStack() {
        return new ArrayList<>();
    }

    public static int mult(long a, long b) {
        return (int) (a * b);
    }

    public static int div(long a, long b) {
        return (int) (a / b);
    }
}
