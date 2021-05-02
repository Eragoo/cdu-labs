package com.Eragoo.Lab4;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.Collection;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

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
}