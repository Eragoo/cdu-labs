package com.Eragoo.Lab3;

import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;

import java.io.Serializable;
import java.util.Collection;
import java.util.Map;
import java.util.Objects;
import java.util.TreeMap;
import java.util.stream.Collectors;

@AllArgsConstructor
@NoArgsConstructor
public class WoodDirectory implements Store<Wood>, Serializable {
    private TreeMap<Long, Wood> storage = new TreeMap<>();

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

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        WoodDirectory that = (WoodDirectory) o;
        return storage.equals(that.storage);
    }

    @Override
    public int hashCode() {
        return Objects.hash(storage);
    }
}
