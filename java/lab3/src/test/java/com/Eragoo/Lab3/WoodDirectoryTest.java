package com.Eragoo.Lab3;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import java.io.*;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Matchers.anyLong;

class WoodDirectoryTest {
    private WoodDirectory woodDirectory;

    @BeforeEach
    void init() {
        woodDirectory = new WoodDirectory();
    }

    @Test
    @DisplayName("Get value from empty directory should return null")
    void getNotPresented() {
        Wood wood = woodDirectory.get(anyLong());
        assertNull(wood);
    }

    @Test
    @DisplayName("Init directory with Wood and get it")
    void getPresented() {
        Wood expected = new Wood(1L, "Sample", 0.1f);
        woodDirectory = new WoodDirectory(List.of(expected));
        assertEquals(expected, woodDirectory.get(1L));
    }

    @Test
    @DisplayName("Add not presented Wood should return true")
    void addNotPresented() {
        Wood value = new Wood(1L, "Sample", 0.1f);
        assertTrue(woodDirectory.add(value));
    }

    @Test
    @DisplayName("Add presented Wood should false")
    void addPresented() {
        Wood prevValue = new Wood(1L, "Sample1", 0.1f);
        Wood currentValue = new Wood(1L, "Sample2", 0.1f);
        woodDirectory = new WoodDirectory(List.of(prevValue));
        woodDirectory.add(currentValue);

        assertEquals(false, woodDirectory.add(currentValue));
    }

    @Test
    @DisplayName("Serialization and deserialization test")

    void serializeWoodDirectory() {
        woodDirectory.add(new Wood(1L, "Sample1", 0.1f));
        File file = new File("WoodDirectory.object");
        try {
            ObjectOutputStream os = new ObjectOutputStream(new FileOutputStream(file));
            os.writeObject(woodDirectory);

            ObjectInputStream is = new ObjectInputStream(new FileInputStream(file));
            WoodDirectory parsed = (WoodDirectory) is.readObject();
            assertEquals(woodDirectory, parsed);
        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
}