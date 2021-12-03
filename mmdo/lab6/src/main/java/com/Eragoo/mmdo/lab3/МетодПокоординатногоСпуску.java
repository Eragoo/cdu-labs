package com.Eragoo.mmdo.lab3;

import org.apache.commons.math3.linear.ArrayRealVector;

import java.util.Arrays;

public abstract class МетодПокоординатногоСпуску {
    public abstract double f(double[] x);

    public double[] xResp;
    public double fxResp;

    public void solve(double[] x0, double eps, double lambda, double h0, int n) {
        double[] h = new double[x0.length];
        for (int i = 0; i < n; i++) {
            h[i] = h0;
        }

        double[] x_int = Arrays.copyOf(x0, x0.length);
        double[] x_ext = Arrays.copyOf(x_int, x_int.length);

        double xIntSubXEpxNorm;
        do {
            double[] x;
            for (int i = 0; i < n; i++) {
                x = Arrays.copyOf(x_int, x_int.length);
                double fx = f(x);

                double[] y1 = Arrays.copyOf(x, x.length);
                double[] y2 = Arrays.copyOf(x, x.length);
                y1[i] = y1[i] + (3 * eps);
                y2[i] = y2[i] - (3 * eps);

                double f1 = f(y1);
                double f2 = f(y2);
                double z = Math.signum(f2 - f1);

                double fx1;
                do {
                    x_int[i] = x[i] + (h[i] * z);
                    fx1 = f(x_int);

                    if (fx1 >= fx) {
                        h[i] = lambda * h[i];
                    }

                } while (!(fx1 < fx || h[i] < (eps / 2)));
            }

            xIntSubXEpxNorm = new ArrayRealVector(x_int).subtract(new ArrayRealVector(x_ext)).getNorm();
        } while (!(xIntSubXEpxNorm < eps));

        xResp = Arrays.copyOf(x_int, x_int.length);
        fxResp = f(x_int);
    }

    @Override
    public String toString() {
        return "Метод Покоординатного Спуску   " +
                "x : " + Arrays.toString(xResp) +
                ", f(x) : " + fxResp;
    }
}
