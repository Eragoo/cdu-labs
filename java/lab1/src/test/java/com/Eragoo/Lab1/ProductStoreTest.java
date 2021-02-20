package com.Eragoo.Lab1;

import org.junit.jupiter.api.*;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;
import static org.mockito.Matchers.any;

class ProductStoreTest {
    private ProductStore productStore;
    @BeforeEach
    void init() {
        productStore = new ProductStore();
    }

    @Test
    @DisplayName("Add element should return true")
    void add() {
        assertTrue(productStore.add(new Timber(null ,0, 0 ,0)));
    }

    @Test
    @DisplayName("Should return number of added elements")
    void size() {
        productStore.add(any());
        productStore.add(any());
        assertEquals(2, productStore.size());
    }
}