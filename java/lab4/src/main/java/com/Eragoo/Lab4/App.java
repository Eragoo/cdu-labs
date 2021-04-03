package com.Eragoo.Lab4;

import lombok.SneakyThrows;

import javax.swing.*;
import java.awt.*;
import java.io.File;
import java.io.FileWriter;
import java.time.Instant;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class App {
    @SneakyThrows
    public static void main(String[] args) {
        StringBuffer stringBuffer = new StringBuffer();
        Scanner in = new Scanner(System.in);
        System.out.println("Specify username:");
        String userName = in.nextLine();
        System.out.println("Creating wood repository.\n Specify number of wood:");
        int woodCount = Integer.valueOf(in.nextLine());
        System.out.println("Specify wood density:");
        float woodDensity = Float.valueOf(in.nextLine());

        List<Wood> woods = new ArrayList<>();
        for (int i = 1; i <= woodCount; i++) {
            Wood wood = new Wood(i, "wood" + i, woodDensity);
            stringBuffer.append(Instant.now().toString() + " " + userName + " added wood: " + wood.toString());
            woods.add(wood);
        }
        WoodDirectory woodDirectory = new WoodDirectory(woods);
        System.out.println(woodDirectory);

        File logsFile = getFileForLogs();
        FileWriter fw = new FileWriter(logsFile);
        fw.append(stringBuffer);
        fw.flush();
        fw.close();
    }

    /**
     * Swing issue about macOS
     * EventQueue.invokeAndWait causes runnable to have its run method called in the dispatch thread of the system EventQueue
     */
    @SneakyThrows
    private static File getFileForLogs() {
        final File[] file = new File[1];
        UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());

        EventQueue.invokeAndWait(() -> {
            JFileChooser fileChooser = new JFileChooser();
            fileChooser.setDialogTitle("Choose file for logs");
            fileChooser.setFileSelectionMode(JFileChooser.FILES_ONLY);
            fileChooser.setApproveButtonText("Open");
            fileChooser.showOpenDialog(null);
            file[0] = fileChooser.getSelectedFile();
        });

        return file[0];
    }
}
