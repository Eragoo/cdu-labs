package com.Eragoo.mmdo.lab3;

import org.apache.commons.math3.linear.ArrayRealVector;

import java.util.Arrays;

public abstract class ГрадієнтнийМетодЗПоділомКроку {
    public abstract double f(double[] x);

    public abstract double[] grad_f(double[] x);

    public void solve(int n, double[] x0, double h, double lambda, double eps) {
        double[] g = grad_f(x0);
        double gNorm = getNorm(g);
        if (gNorm <= eps) {
            System.out.print("Градієнтний метод з поділом кроку  f(x) = " + f(x0) + " x1 = " + x0[0] + " x2 = " + x0[1]);
            return;
        }

        double xSubX0Norm;
        do {
            double[] x = Arrays.copyOf(x0, x0.length);
            double fx = f(x);

            double f0;
            do {
                for (int i = 0; i < n; i++) {
                    x0[i] = x[i] - (h * g[i]);
                }

                f0 = f(x0);

                if ((f0 - fx) > (-1 * lambda * h * gNorm * gNorm)) {
                    h = lambda * h;
                }

            } while (!(f0 - fx <= (-1 * lambda * h * gNorm * gNorm) || h < (eps / 2d)));

            g = grad_f(x0);
            gNorm = getNorm(g);

            xSubX0Norm = new ArrayRealVector(x).subtract(new ArrayRealVector(x0)).getNorm();
        } while (!(xSubX0Norm < eps || getNorm(g) < eps));

        System.out.print("Градієнтний метод з поділом кроку  f(x) = " + f(x0) + " x1 = " + x0[0] + " x2 = " + x0[1]);
    }

    private double getNorm(double[] g) {
        return new ArrayRealVector(g).getNorm();
    }
}
