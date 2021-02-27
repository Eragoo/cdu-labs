package com.Eragoo.Lab2;

import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;

import java.util.Collection;
import java.util.Map;
import java.util.TreeMap;
import java.util.stream.Collectors;

@AllArgsConstructor
@NoArgsConstructor
public class WoodDirectory implements Store<Wood> {
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

    public boolean add(Wood wood) {
        if (storage.containsKey(wood.getId())) {
            return false;
        }
        storage.put(wood.getId(), wood);
        return true;
    }

    @Override
    public int size() {
        return storage.size();
    }

    @Override
    public String toString() {
        return "WoodDirectory{" +
                "storage=" + storage +
                '}';
    }
}
