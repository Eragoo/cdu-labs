package com.eragoo.systemmodeling.lab4.lab4;

public class Gauss {
    private static final String TAB = String.format("%s%d%s", "%", 8, ".1f");
    private final double[][] matrix;
    private final double[] answers;
    private final boolean[] lines;

    public Gauss(int[][] matrix, int[] answers) {
        checkArguments(matrix, answers);
        this.matrix = parceMatrixIntToDouble(matrix);
        this.answers = parseIntToDouble(answers);
        this.lines = new boolean[answers.length];
    }

    private void checkArguments(int[][] matrix, int[] answers) {

        if (answers == null || answers.length == 0) {
            throw new IllegalArgumentException("Answers is null or empty");
        }
        if (matrix == null || matrix.length == 0) {
            throw new IllegalArgumentException("Matrix is null or empty");
        }
        if (matrix.length != answers.length) {
            throw new IllegalArgumentException("Matrix and answers have different length");
        }
        if (!checkSquareMatrix(matrix)) {
            throw new IllegalArgumentException("Matrix is not square");
        }
    }

    private boolean checkSquareMatrix(int[][] matrix) {
        boolean result = true;
        int size = matrix.length;
        for (int[] line : matrix) {
            if (line.length != size) {
                result = false;
                break;
            }
        }
        return result;
    }

    private double[][] parceMatrixIntToDouble(int[][] matrix) {
        double[][] result = new double[matrix.length][];
        int count = 0;
        for (int[] line : matrix) {
            result[count++] = parseIntToDouble(line);
        }
        return result;
    }

    private double[] parseIntToDouble(int[] line) {
        double[] result = new double[line.length];
        for (int i = 0; i < line.length; i++) {
            result[i] = line[i];
        }
        return result;
    }

    double[] start() {
        printSlau(this.matrix, this.answers);
        double element;
        int index;
        int row = 0;
        while (!isEnd(this.lines)) {
            index = getMinIndex(this.matrix, this.lines, row);
            element = matrix[index][row];
            divToElement(this.matrix[index], element);
            this.answers[index] /= element;
            printSlau(this.matrix, this.answers);
            toNullifyElements(this.matrix, this.answers, index, row);
            printSlau(this.matrix, this.answers);
            this.lines[index] = true;
            row++;
        }
        return getAnswer(this.matrix, this.answers);
    }

    private double[] getAnswer(double[][] matrix, double[] answers) {
        double[] result = new double[answers.length];
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[i].length; j++) {
                if (matrix[i][j] == 1.) {
                    result[j] = answers[i];
                }
            }
        }
        return result;
    }

    private boolean isEnd(boolean[] lines) {
        boolean result = true;
        for (boolean index : lines) {
            if (!index) {
                result = false;
                break;
            }
        }
        return result;
    }

    private void toNullifyElements(double[][] matrix, double[] answers, int exceptLine, int row) {
        for (int i = 0; i < matrix.length; i++) {
            if (i == exceptLine) {
                continue;
            }
            double first = matrix[i][row];
            for (int j = 0; j < matrix[i].length; j++) {
                if (matrix[i][j] != 0.) {
                    matrix[i][j] -= first * matrix[exceptLine][j];
                }
            }
            if (answers[i] != 0.) {
                answers[i] -= first * answers[exceptLine];
            }
        }
    }

    private void divToElement(double[] line, double div) {
        for (int index = 0; index < line.length; index++) {
            if (line[index] != 0.) {
                line[index] /= div;
            }
        }
    }

    private void printSlau(double[][] matrix, double[] answers) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < answers.length; i++) {
            sb.append("|");
            for (int j = 0; j < matrix[i].length; j++) {
                sb.append(" ").append(String.format(TAB, matrix[i][j]));
            }
            sb.append(" | ").append(String.format(TAB, answers[i])).append(" |\n");
        }
        System.out.println(sb);
    }

    private int getMinIndex(double[][] matrix, boolean[] lines, int index) {
        int res = -1;
        double min = Integer.MAX_VALUE;
        for (int i = 0; i < matrix.length; i++) {
            if (!lines[i] && Math.abs(matrix[i][index]) < Math.abs(min) && matrix[i][index] != 0) {
                res = i;
                min = matrix[i][index];
            }
        }
        return res;
    }
}
