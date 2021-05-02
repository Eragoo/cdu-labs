package com.Eragoo.lab5;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.Collection;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

class WoodDirectoryTest {
    WoodDirectory woods;
    @BeforeEach
    void init() {
        woods = new WoodDirectory();
    }

    @Test
    void map() {
        Wood test = new Wood(1L, "Test", 1f);
        Wood expected = new Wood(test.getId(), test.getName() + " mapped", test.getDensity());
        woods.add(test);
        List<Wood> mappedWoods = woods.map(wood -> new Wood(wood.getId(), wood.getName() + " mapped", wood.getDensity())).getList();
        assertEquals(1, mappedWoods.size());
        assertEquals(expected, mappedWoods.get(0));
    }

    @Test
    void wasteThatMatches() {
        Wood test = new Wood(1L, "Test", 1f);
        Waste expected = new Waste(1);
        woods.add(test);
        Collection<Waste> waste = woods.wasteThatMatches(wood -> true);
        assertEquals(1, waste.size());
        assertEquals(expected, waste.stream().findFirst().get());
        assertEquals(0, woods.size());
    }

    @Test
    void remove() {
        Wood test = new Wood(1L, "Test", 1f);
        woods.add(test);
        woods.remove(w -> w.getId() == 1L);
        assertEquals(0, woods.size());
    }

    @Test
    void doOnlyFor() {
        Wood test = new Wood(1L, "Test", 1f);
        Wood test2 = new Wood(2L, "Test", 1f);

        woods.add(test);
        woods.add(test2);

        woods.doOnlyFor(w->w.getId()==1L,  w->w.setName("Edited"));
        assertEquals("Edited", woods.get(1L).getName());
        assertEquals(2, woods.size());
    }
}