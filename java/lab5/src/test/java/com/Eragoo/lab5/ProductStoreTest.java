package com.Eragoo.lab5;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.Collection;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

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

    @Test
    void removeTest() {
        Wood wood = new Wood(1L, "Test", 1);
        Timber test = new Timber(wood,1,1,1);
        productStore.add(test);
        productStore.remove(w -> w.getWeight() > 0);

        assertEquals(0, productStore.size());
    }

    @Test
    void doOnlyFor() {
        Wood wood = new Wood(1L, "Test", 1);
        Timber test = new Timber(wood,1,1,1);

        Wood wood2 = new Wood(1L, "Test2", 1);
        Timber test2 = new Timber(wood2,2,2,2);

        productStore.add(test);
        productStore.add(test2);

        productStore.doOnlyFor(t->t.getWeight() > 7, t-> System.out.println(t.getWeight()));

        assertEquals(2, productStore.size());
    }
}