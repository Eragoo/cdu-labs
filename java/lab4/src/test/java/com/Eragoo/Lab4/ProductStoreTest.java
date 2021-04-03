package com.Eragoo.Lab4;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.Collection;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class ProductStoreTest {
    ProductStore productStore;
    @BeforeEach
    void init() {
        productStore = new ProductStore();
    }

    @Test
    void map() {
        Wood wood = new Wood(1L, "Test", 1);
        Timber test = new Timber(wood,1,1,1);
        Timber expected = new Timber(wood, 2,2,2);
        productStore.add(test);
        List<Weightable> mapped = productStore.map(timber -> new Timber(wood,2,2,2)).getList();
        assertEquals(1, mapped.size());
        assertEquals(expected.getWeight(), mapped.get(0).getWeight());
    }

    @Test
    void wasteThatMatches() {
        Wood wood = new Wood(1L, "Test", 1);
        Timber test = new Timber(wood,1,1,1);
        productStore.add(test);
        Collection<Waste> wastes = productStore.wasteThatMatches(timber -> true);
        assertEquals(1, wastes.size());
        assertEquals(0, productStore.size());
    }
}