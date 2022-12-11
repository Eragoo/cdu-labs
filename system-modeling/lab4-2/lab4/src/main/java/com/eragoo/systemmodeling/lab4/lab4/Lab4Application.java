package com.eragoo.systemmodeling.lab4.lab4;


import java.util.Scanner;

public class Lab4Application {

    public static void main(String[] args) {
        // результат 1 рівняння та змінні
        int res1;int x11;int X12;int x13;int x14;
        // результат 2 рівняння та змінні
        int res2;int x21;int x22;int x23;int x24;
        // результат 3 рівняння та змінні
        int res3;int x31;int x32;int x33;int x34;
        // результат 4 рівняння та змінні
        int res4;int x41;int x42;int x43;int x44;
        // введення початкових даних
        Scanner scanner = new Scanner(System.in);

        System.out.println("Введіть 1 число: ");
        int a1 = scanner.nextInt();
        System.out.println("Введіть 2 число: ");
        int a2 = scanner.nextInt();
        System.out.println("Введіть 3 число: ");
        int a3=scanner.nextInt();
        System.out.println("Введіть 4 число: ");
        int a4=scanner.nextInt();
        System.out.println("Введіть 5 число: ");
        int a5=scanner.nextInt();
        System.out.println("Введіть 6 число: ");
        int a6=scanner.nextInt();
        System.out.println("Введіть 7 число: ");
        int a7=scanner.nextInt();
        System.out.println("Введіть 8 число: ");
        int a8=scanner.nextInt();

        //змінна кінцевого результату
        double FRes;
        //відхилення
        double M;
        double S;
        double sumS;
        //прогнозуємо 2 елементи, починаючи з 3, тобто прогнозуються перші 2 елементи введеної послідовності
        double h1;
        double h2;



        System.out.println("З введених значень утворюємо систему нормальних рівнянь\n"); // обрахунок функцій
        res1 = a3 + a4 + a5 + a6 + a7 + a8;
        res2 = (a1 * a3) + (a1 * a4) + (a1 * a5) + (a1 * a6) + (a1 * a7) + (a1 * a8);
        res3 = (a2 * a3) + (a2 * a4) + (a2 * a5) + (a2 * a6) + (a2 * a7) + (a2 * a8);
        res4 = (a1 * a2 * a3) + (a1 * a2 * a4) + (a1 * a2 * a5) + (a1 * a2 * a6) + (a1 * a2 * a7) + (a1 * a2 * a8);

        //1 рівняння
        x11 = 6;
        X12 = a1 + a2 + a3 + a4 + a5 + a6;
        x13 = a2 + a3 + a4 + a5 + a6 + a7;
        x14 = (a1 * a2) + (a2 * a3) + (a3 * a4) + (a4 * a5) + (a5 * a6) + (a6 * a7);

        //2 рівняння
        x21 = a1 + a2 + a3 + a4 + a5 + a6;
        x22 = (a1 * a1) + (a2 * a2) + (a3 * a3) + (a4 * a4) + (a5 * a5) + (a6 * a6);
        x23 = (a1 * a2) + (a2 * a3) + (a3 * a4) + (a4 * a5) + (a5 * a6) + (a6 * a7);
        x24 = (a1 * a1 * a2) + (a2 * a2 * a3) + (a3 * a3 * a4) + (a4 * a4 * a5) + (a5 * a5 * a6) + (a6 * a6 * a7);

        //3 рівняння
        x31 = a2 + a3 + a4 + a5 + a6 + a7;
        x32 = (a2 * a1) + (a3 * a2) + (a4 * a3) + (a5 * a4) + (a6 * a5) + (a7 * a6);
        x33 = (a2 * a2) + (a3 * a3) + (a4 * a4) + (a5 * a5) + (a6 * a6) + (a7 * a7);
        x34 = (a2 * a1 * a2) + (a3 * a2 * a3) + (a4 * a3 * a4) + (a5 * a4 * a5) + (a6 * a5 * a6) + (a7 * a6 * a7);

        //4 рівняння
        x41 = (a1 * a2) + (a2 * a3) + (a3 * a4) + (a4 * a5) + (a4 * a5) + (a4 * a5);
        x42 = (a1 * a2 * a1) + (a2 * a3 * a2) + (a3 * a4 * a3) + (a4 * a5 * a4) + (a5 * a6 * a5) + (a6 * a7 * a6);

        x43 = (a1 * a2 * a2) + (a2 * a3 * a3) + (a3 * a4 * a4) + (a4 * a5 * a5) + (a5 * a6 * a6) + (a6 * a7 * a7);
        x44 = (a1 * a2 * a1 * a2) + (a2 * a3 * a2 * a3) + (a3 * a4 * a3 * a4) + (a4 * a5 * a4 * a5) + (a4 * a5 * a5 * a6) + (a4 * a5 * a6 * a7);

        //середнє значення
        M = (a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8) / 8.;

        //прогноз
        h1 = (0.1 * a3) + (0.9 * a2);
        h2 = (0.1 * a4) + (0.9 * h1);

        System.out.println(res1 + " = " + x11 + "a0 + " + X12 + "a1 + " + x13 + "a2 + " + x14 + "a3");
        System.out.println(res2 + " = " + x21 + "a0 + " + x22 + "a1 + " + x23 + "a2 + " + x24 + "a3");
        System.out.println(res3 + " = " + x31 + "a0 + " + x32 + "a1 + " + x33 + "a2 + " + x34 + "a3");
        System.out.println(res4 + " = " + x41 + "a0 + " + x42 + "a1 + " + x43 + "a2 + " + x44 + "a3\n");
        System.out.println("Знайдемо коефіцієнти системи нормальних рівнянь\n");

        int[] answers = {res1, res2, res3, res4};
        int[][] matrix = {
                {x11, X12, x13, x14},
                {x21, x22, x23, x24},
                {x31, x32, x33, x34},
                {x41, x42, x43, x44}
        };
        double[] endMatrixResult = new Gauss(matrix, answers).start();
        System.out.println("Коефіцієнти (округлені для зручності):");
        for (int x = 0; x < endMatrixResult.length; x++) {
            System.out.println(x + 1 + " = " + Math.round(endMatrixResult[x]));
        }
        System.out.println("\n");

        System.out.println("F3 = " + "(" + endMatrixResult[0] + ")" + " + (" + endMatrixResult[1] + ")F1 + " + "(" + endMatrixResult[2] + ")F2 - " + "(" + endMatrixResult[3] + ")F1F2\n");
        System.out.println("Прогноз:\n");
        FRes = endMatrixResult[0] + (endMatrixResult[1] * a7) + (endMatrixResult[2] * a8) - (endMatrixResult[3] * a7 * a8);
        System.out.println("Кінцевий прогноз 1 елементу послідовності:" + FRes);
        sumS = (Math.pow(a1 - M, 2) + Math.pow(a2 - M, 2) + Math.pow(a3 - M, 2) + Math.pow(a4 - M, 2) + Math.pow(a5 - M, 2) + Math.pow(a6 - M, 2) + Math.pow(a7 - M, 2) + Math.pow(a8 - M, 2)) / 8;
        S = Math.sqrt(sumS);
        System.out.println("Відхилення прогнозу:" + S);
        System.out.println("Горизонт прогнозування для 3 елементу:" + h1);
        System.out.println("Горизонт прогнозування для 4 елементу: "+ h2);
    }
}
