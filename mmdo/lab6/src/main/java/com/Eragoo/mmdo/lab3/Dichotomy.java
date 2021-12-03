package com.Eragoo.mmdo.lab3;

import org.apache.commons.math3.util.Precision;

import java.util.function.Predicate;

public abstract class Dichotomy {

    public double[] solve(double a, double b, double eps) {
        double sigma = eps / 3d;
        do {
            double x1 = (a + b - sigma) / 2d;
            double x2 = (a + b + sigma) / 2d;

            double f1 = f(x1);
            double f2 = f(x2);

            if (f1 <= f2) {
                b = x2;
            } else {
                a = x1;
            }
        } while ((b - a) > eps);

        double x0 = (a + b) / 2;
        double f0 = f(x0);
        return new double[]{x0, f0};
    }

    public abstract double f(double x);
}
