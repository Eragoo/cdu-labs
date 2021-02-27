package com.Eragoo.Lab2;

import com.Eragoo.Lab2.ProductStore;
import com.Eragoo.Lab2.Timber;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

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