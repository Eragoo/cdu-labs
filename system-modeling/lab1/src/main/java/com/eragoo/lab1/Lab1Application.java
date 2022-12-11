package com.eragoo.lab1;

import java.util.Arrays;
import java.util.Scanner;
import java.util.Vector;

public class Lab1Application {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.println("Ввведіть лямбда:");
        double l = sc.nextDouble();
        System.out.println("\r\n");
        System.out.println("Ввведіть t_obs:");
        double Tobs = sc.nextDouble();
        System.out.println("\r\n");
        System.out.println("Ввведіть n:");
        int n = sc.nextInt();
        System.out.println("\r\n");
        System.out.println("Ввведіть m:");
        int m = sc.nextInt();
        System.out.println("\r\n");
        //1, 0.5,5, 7
        count(l, Tobs, n, m);
    }
    static void count(double l, double Tobs, int n, int m) {
        // параметр завантаження системи
        double alpha;
        // імовірність того, що всі канали обслуговування вільні
        double Po;
        double sumPo1 = 0;
        double sumPo2 = 0;
        // імовірність того, що к каналів зайняті
        double[] sPk = new double[10];
        double[] sPo = new double[10];
        // середня довжина черги
        double[] Moch = new double[10];
        // середня тривалість очікування вимогою початку обслуговування
        double[] Toch = new double[10];
        double sMoch = 0;
        // середня кількість вимог у системи
        double[] sMc1 = new double[10];
        double[] sMc2 = new double[10];
        // середня кількість вільних каналів обслуговування
        // double No[] = new double[100];
        double[] sNo1 = new double[10];
        double[] sNo2 = new double[10];
        alpha = l * Tobs; // параметр завантажуваності системи
        // обрахунок ймовірності, що всі канали обслуговування вільні
        for (int k = 0; k <= n; k++) {
            sumPo1 = sumPo1 + ((getFactorial(m) * Math.pow(alpha, k)) / (getFactorial(k) * getFactorial(m - k)));
        }
        for (int k = n + 1; k <= m; k++) {
            sumPo2 = sumPo2 + ((getFactorial(m) * Math.pow(alpha, k)) / (Math.pow(n, k - n) * getFactorial(n) * getFactorial(m - k)));
        }
        Po = 1 / (sumPo1 + sumPo2);

        for (int k = 0; k < n; k++) {
            // імовірність що канали зайняті
            sPk[k] = (getFactorial(m) * Math.pow(alpha, k)) / ((getFactorial(k) * getFactorial(m - k)));
            // середня кількість вимог у системі
            sMc1[k] = sMc1[k] + (k * sPk[k] * Po);
            // середня кількість вільних каналів осбслуговування
            sNo1[k] = sNo1[k] + ((n - k) * sPk[k] * Po);
        }
        for (int k = n; k <= m; k++) {
            // імовірність що к канали зайняті
            sPo[k] = (getFactorial(m) * Math.pow(alpha, k)) / (Math.pow(n, k - n) * getFactorial(n) * getFactorial(m - k));
            // середня кількість вимог у системі
            sMc2[k] = sMc2[k] + (k * sPo[k] * Po);
            // середня кількість вільних каналів осбслуговування
            sNo2[k] = sNo2[k] + ((n - k) * sPo[k] * Po);
        }
        //середня довжина черги
        for (int k = n; k <= m; k++) {
            Moch[k] = Moch[k] + ((k - n) * getFactorial(m) * Math.pow(alpha, k)) / (Math.pow(n, k - n) * getFactorial(n) * getFactorial(m - k)) * Po;
            sMoch += Moch[k];
            // середня тривалість очікування початку обслуговування
            Toch[k] = Moch[k] / l;
        }
        Vector<Double> vec = new Vector<>();
        Vector<Double> vec1 = new Vector<>();
        Vector<Double> vec2 = new Vector<>();
        Vector<Double> vec3 = new Vector<>();
        Vector<Double> vec4 = new Vector<>();
        Vector<Double> vec5 = new Vector<>();
        Vector<Double> vec6 = new Vector<>();
        Vector<Double> vec7 = new Vector<>();

        for (int i = 0; i < Toch.length; i++) {
            if (Toch[i] != 0)
                vec.add(Toch[i]);
        }
        for (int i = 0; i < sPk.length; i++) {
            if (sPk[i] != 0)
                vec1.add(sPk[i]);
        }
        for (int i = 0; i < sPo.length; i++) {
            if (sPo[i] != 0)
                vec2.add(sPo[i]);
        }
        for (int i = 0; i < sNo1.length; i++) {
            if (sNo1[i] != 0)
                vec3.add(sNo1[i]);
        }
        for (int i = 0; i < sNo2.length; i++) {
            if (sNo2[i] != 0)
                vec4.add(sNo2[i]);
        }
        for (int i = 0; i < sMc1.length; i++) {
            if (sMc1[i] != 0)
                vec5.add(sMc1[i]);
        }
        for (int i = 0; i < sMc2.length; i++) {
            if (sMc2[i] != 0)
                vec6.add(sMc2[i]);
        }
        for (int i = 0; i < Moch.length; i++) {
            if (Moch[i] != 0)
                vec7.add(Moch[i]);
        }

        System.out.println("Імовірність що всі канали обслуговування вільні:\r\n " + Po);
        System.out.println("Імовірність що (1-n) канали зайняті:\r\n" + Arrays.toString(vec1.toArray()));
        System.out.println("Імовірність що m-n каналів зайняті:\r\n " + Arrays.toString(vec2.toArray()));
        System.out.println("Середня кількість вільних каналів в системі(1-n):\r\n " + Arrays.toString(vec3.toArray()));
        System.out.println("Середня кількість вільних каналів в системі (n-m):\r\n " + Arrays.toString(vec5.toArray()));
        System.out.println("Середня кількість вимог у системі(1-n):\r\n " + Arrays.toString(vec6.toArray()));
        System.out.println("Середня кількість вимог у системі(n-m):\r\n " + Arrays.toString(vec7.toArray()));
        System.out.println("Середня довжина черги:\r\n " + sMoch);
        System.out.println("Середня тривалість очікування початку обслуговування:\r\n " + Arrays.toString(vec.toArray()));
    }

    public static int getFactorial(int f) {
        int result = 1;
        for (int i = 1; i <= f; i++) {
            result = result * i;
        }
        return result;
    }
}
