package com.Eragoo.mmdo.lab3;

import org.junit.jupiter.api.Test;

import java.util.Arrays;

public class Lab6Test {
    public int fCallCount = 0;

    @Test
    void solve() {
        int n = 2;
        double[] x0 = {-2, 1};
        double eps = 0.001;
        double h = 2;
        double lambda = 0.8;

        ПокоординатнийСпуск coo = new ПокоординатнийСпуск();
        coo.solve(Arrays.copyOf(x0, x0.length), eps, lambda, h, n);
        System.out.println(" n : " + fCallCount);
        fCallCount = 0;
        System.out.println();

        НайшвидшийСпуск fas = new НайшвидшийСпуск();
        fas.solve(Arrays.copyOf(x0, x0.length), n, h, eps);
        System.out.println("  n : " + fCallCount);
        fCallCount = 0;
        System.out.println();

        ПоділКроку поділКроку = new ПоділКроку();
        поділКроку.solve(n, Arrays.copyOf(x0, x0.length), h, lambda, eps);
        System.out.println(" n : " + fCallCount);
        fCallCount = 0;
        System.out.println();
    }

    public double f2(double[] x) {
        fCallCount += 1;
        return (5 * x[0] * x[0]) + (x[0] * x[1]) + (25 * x[1] * x[1]) - (4 * x[0]) + (6 * x[1]);
    }

    public double f1(double[] x) {
        fCallCount += 1;
        return (100 * Math.pow((x[1] - (x[0] * x[0])), 2)) + Math.pow(1 - x[0], 2);
    }

    public static double[] grad_f2(double[] x) {
        return new double[]{
                (10 * x[0]) + x[1] - 4,
                x[0] + (50 * x[1]) + 6
        };
    }

    public static double[] grad_f1(double[] x) {
        return new double[]{
                (-400 * x[0] * (x[1] - (x[0] * x[0]))) + (2 * x[0]) - 2,
                (200 * x[1]) - (200 * x[0] * x[0])
        };
    }

    class ПоділКроку extends ГрадієнтнийМетодЗПоділомКроку {

        @Override
        public double f(double[] x) {
            return f2(x);
        }

        @Override
        public double[] grad_f(double[] x) {
            return grad_f2(x);
        }
    }

    class НайшвидшийСпуск extends МетодНайшвидшогоСпуску {

        @Override
        public double f(double[] x) {
            return f2(x);
        }

        @Override
        public double[] grad_f(double[] x) {
            return grad_f2(x);
        }
    }

    class ПокоординатнийСпуск extends МетодПокоординатногоСпуску {

        @Override
        public double f(double[] x) {
            return f2(x);
        }
    }


}
