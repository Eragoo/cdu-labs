package com.Eragoo.Lab1;

import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;

import java.util.*;
import java.util.stream.Collectors;

@AllArgsConstructor
@NoArgsConstructor
public class WoodDirectory {
    private TreeMap<Long, Wood> storage = new TreeMap<>();

    public WoodDirectory(Map<Long, Wood> storage) {
        this.storage = new TreeMap<>(storage);
    }

    public WoodDirectory(Collection<Wood> woods) {
        this.storage = new TreeMap<>(
                woods.stream().collect(Collectors.toMap(Wood::getId, Wood::new))
        );
    }

    public Wood get(long id) {
        return storage.get(id);
    }

    public Wood add(Wood wood) {
        return storage.putIfAbsent(wood.getId(), wood);
    }

    @Override
    public String toString() {
        return "WoodDirectory{" +
                "storage=" + storage +
                '}';
    }
}
