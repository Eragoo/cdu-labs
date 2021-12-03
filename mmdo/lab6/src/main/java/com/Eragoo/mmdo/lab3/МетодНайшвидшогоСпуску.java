package com.Eragoo.mmdo.lab3;

import org.apache.commons.math3.linear.ArrayRealVector;

import java.util.Arrays;

public abstract class МетодНайшвидшогоСпуску {
    public abstract double f(double[] x);

    public abstract double[] grad_f(double[] x0);

    public void solve(double[] x0, int n, double h0, double eps) {
        double[] g = grad_f(x0);
        if (new ArrayRealVector(g).getNorm() <= eps) {
            System.out.print("Метод найшвидшого спуску    f(x) = " + f(x0) + " x1 = " + x0[0] + " x2 = " + x0[1]);
            return;
        }

        double xSubX0Norm;
        do {
            double[] x = Arrays.copyOf(x0, x0.length);
            double h = find_h(x, g, h0, eps);

            for (int i = 0; i < n; i++) {
                x0[i] = x[i] - (h * g[i]);
            }

            g = grad_f(x0);

            xSubX0Norm = new ArrayRealVector(x).subtract(new ArrayRealVector(x0)).getNorm();
        } while (!(xSubX0Norm < eps || new ArrayRealVector(g).getNorm() < eps));

        System.out.print("Метод найшвидшого спуску    f(x) = " + f(x0) + " x1 = " + x0[0] + " x2 = " + x0[1]);
    }

    public double find_h(double[] x0, double[] g, double h0, double eps) {
        double h = 0;
        double f1 = f(x0);
        double[] x2 = new double[x0.length];
        double f2;

        do {
            h0 = h0 / 2;

            for (int i = 0; i < x0.length; i++) {
                x2[i] = x0[i] - (h0 * g[i]);
            }

            f2 = f(x2);

        } while (!(f1 > f2 || h0 < eps));

        if (h0 <= eps) {
            return h;
        }

        double[] x1;

        do {
            x1 = Arrays.copyOf(x2, x2.length);;
            f1 = f2;
            h = h + h0;

            for (int i = 0; i < x1.length; i++) {
                x2[i] = x1[i] - (h * g[i]);
            }
            f2 = f(x2);

        } while (!(f1 < f2));


        double ha = h - (2 * h0);
        double hb = h;
        double sigma = eps / 3;

        do {
            double h1 = (ha + hb - sigma) / 2;
            double h2 = (ha + hb + sigma) / 2;

            for (int i = 0; i < x0.length; i++) {
                x1[i] = x0[i] - (h1 * g[i]);
                x2[i] = x0[i] - (h2 * g[i]);
            }

            f1 = f(x1);
            f2 = f(x2);

            if (f1 <= f2) {
                hb = h2;
            } else {
                ha = h1;
            }

        } while (!(hb - ha < eps));

        return (ha + hb) / 2;
    }
}
