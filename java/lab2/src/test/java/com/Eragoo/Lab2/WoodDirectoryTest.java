package com.Eragoo.Lab2;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertNull;
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
        Wood expected = new Wood(1L, "Sample", 0);
        woodDirectory = new WoodDirectory(List.of(expected));
        assertEquals(expected, woodDirectory.get(1L));
    }

    @Test
    @DisplayName("Add not presented Wood should return null")
    void addNotPresented() {
        Wood value = new Wood(1L, "Sample", 0);
        assertNull(woodDirectory.add(value));
    }

    @Test
    @DisplayName("Add presented Wood should false")
    void addPresented() {
        Wood prevValue = new Wood(1L, "Sample1", 0);
        Wood currentValue = new Wood(1L, "Sample2", 0);
        woodDirectory = new WoodDirectory(List.of(prevValue));
        woodDirectory.add(currentValue);

        assertEquals(false, woodDirectory.add(currentValue));
    }
}