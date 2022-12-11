package com.eragoo.systemmodeling.lab4.lab4;

public class Main {
    public static void main(String[] args) {
        int[] values = {10,14,15,18,13,12,11,15};
        for (int i = 0; i < values.length-1; i++) {
            System.out.println(getValue(values[i], values[i+1]));
        }
    }

    private static double getValue(int f1, int f2) {
        return (41.16924071381752) + ((-4.776729345781828)*f1) + ((6.894852226282576)*f2) - ((-0.30087248048182946)*f1*f2);
    }
}
